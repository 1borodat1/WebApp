using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Net.Http;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
	[Route("Main")]
    public class MainController : Controller
    {

		[Route("Main")]
		public IActionResult Main() {
			return View();
		}

		[HttpPost]
		[Route("MainProcess")]
		public IActionResult MainProcess(MainModel model) {
			var client = new RestClient("https://localhost:44397/api/lemmatization");
			var request = new RestRequest(Method.POST);
			request.AddHeader("Postman-Token", "168c8ebd-af1b-4bd4-89cb-353420dabe6a");
			request.AddHeader("Cache-Control", "no-cache");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("undefined", "\"" + model.Text + "\"", ParameterType.RequestBody);
			var response = client.Execute(request);
			if (response.IsSuccessful) {
				ModelState.Clear();
				model.LemmatizedText = response.Content;
			}
			return View(model);
		}

	}
}