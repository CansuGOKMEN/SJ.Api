using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SJ.Api.Core.Components;
using SJ.Api.Core.Model;
using SJ.Api.Core.Repository.Base;
using SJ.Api.UI.Models;

namespace SJ.Api.UI.Controllers
{
    public class HomeController : Controller
    {
        private ApiClient apiClient;
        private IInsuranceRepository insuranceRepository;
        private IResultRepository resultRepository;
        public HomeController(ApiClient apiClient, IInsuranceRepository insuranceRepository, IResultRepository resultRepository)
        {
            this.apiClient = apiClient;
            this.insuranceRepository = insuranceRepository;
            this.resultRepository = resultRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id.HasValue)
            {
                Insurance insurance = insuranceRepository.Get(id.Value);
                return await Task.Run(() => View(insurance));
            }
            else
                return await Task.Run(() => View());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Insurance insurance)
        {
            if (insurance == null)
                return View();

            int id = insuranceRepository.Add(insurance);
            insurance.Id = id;

            ApiResponse response = await apiClient.AllInformation(insurance);
            if (!response.success) throw new Exception("Something wrong!"); // Exception handler not included.

            insurance.Result = response.data;
            bool isUpdated = insuranceRepository.Update(insurance);
            if(!isUpdated) throw new Exception("Something wrong!");

            ApiResultViewModel resultModel = JsonConvert.DeserializeObject<ApiResultViewModel>(response.data);
            var model = resultModel.Results.GroupBy(x => x.Status.Value).ToList();

            return await Task.Run(() => View(resultModel.Results));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
