using Android.App;
using Android.Widget;
using Android.OS;


using Microsoft.ProjectOxford.Vision;
using System;
using System.IO;
//using Microsoft.ProjectOXford.Vision;

using System.Text;
using System.Net.Http;

//using System.Web;

using System.Net.Http.Headers;
using System.Web;
using System.Net;
using RestSharp;
using Microsoft.ProjectOxford.Vision.Contract;
using Android.Util;

namespace ProjectOxford
{
	public class RootObject
	{
		public string Url { get; set; }
	}

	[Activity(Label = "ProjectOxford", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		string optionStr = string.Empty;
		string imagePathorUrl = string.Empty;
		private IVisionServiceClient visionClient;

		HttpResponseMessage response;

		async void AnalyzeImage(string imagePathOrUrl)
		{

			//			this.ShowInfo ("Analyzing");
			AnalysisResult analysisResult = null;

			string resultStr = string.Empty;
			try
			{
				if (File.Exists(imagePathOrUrl))
				{
					using (FileStream stream = File.Open(imagePathOrUrl, FileMode.Open))
					{
						analysisResult = this.visionClient.AnalyzeImageAsync(stream).Result;
						Console.Write(analysisResult);

					}
				}
				else if (Uri.IsWellFormedUriString(imagePathOrUrl, UriKind.Absolute))
				{
					analysisResult = visionClient.AnalyzeImageAsync(imagePathOrUrl, null).Result;
					Console.Write(analysisResult);

				}
				else {
					//					this.ShowError ("Invalid image path or Url");
				}
			}
			catch (ClientException e)
			{
				if (e.Error != null)
				{
					Console.Write(e.Error.Message);
					//					this.ShowError (e.Error.Message);
				}
				else {
					Console.Write(e.Error.Message);

					//					this.ShowError (e.Message);
				}

				return;
			}
			catch (Exception)
			{
				//				this.ShowError ("Some error happened.");
				return;
			}

			Console.Write(analysisResult);

			//			this.ShowAnalysisResult (analysisResult);
		}


		protected override async void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);


			var but = FindViewById<Button>(Resource.Id.myButton);

			but.Click += delegate
			{
				Log.Debug("r", response.Content.ReadAsStringAsync().Result);
			};
			RootObject ro = new RootObject();
			XRequest();
			//			this.visionClient = new VisionServiceClient ("c37ff7c34db145e9b73cf2630308fb07");
			//			try {
			//				
			//				visionClient = new VisionServiceClient ("c37ff7c34db145e9b73cf2630308fb07");
			//
			//			} catch (Exception ex) {
			//
			//			} finally {
			//				AnalyzeImage ("https://scontent-ams3-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/10247239_826866984028483_1194786633566871632_n.jpg?oh=a865d983a6ba6f6eedbcb5715f3834dc&oe=56D4DBB5");
			//
			//			}

			//			var client = new RestClient ("https://api.projectoxford.ai/vision/v1/analyses?");
			//
			//			var request = new RestRequest ("visualFeatures=All", Method.POST);
			//			request.AddHeader ("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");
			//			request.AddHeader ("Content-Type", "application/json");
			////			request.AddBody ("{ \"Url\": \"https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b\"}");
			//			var response = client.Execute (request);
			//			Console.Write (response);


			//			var person = new RootObject () { Url = "http://screenshots.en.sftcdn.net/blog/en/2013/09/Cortanaheader-664x374.png" };
			//
			//
			//			var dd = Method.POST;
			//			var client = new RestClient ("https://api.projectoxford.ai");
			//			var request = new RestRequest ("vision/v1/analyses?visualFeatures=All", dd);
			//
			//			request.AddHeader ("Accept", "application/json");
			//			request.AddHeader ("Content-Type", "application/json");
			//			request.AddHeader ("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");
			//			request.AddParameter ("Host", "api.projectoxford.ai");
			//			request.AddParameter ("Content-Length", "215");
			////			request.AddBody (new RootObject{ Url = "https://scontent-ams3-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/10247239_826866984028483_1194786633566871632_n.jpg?oh=a865d983a6ba6f6eedbcb5715f3834dc&oe=56D4DBB5" }); //("Url", "https://scontent-ams3-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/10247239_826866984028483_1194786633566871632_n.jpg?oh=a865d983a6ba6f6eedbcb5715f3834dc&oe=56D4DBB5");  //  ("{ \"Url\": \"https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b\"}");
			//
			//			request.AddBody (person);
			////			request.AddParameter ("Url", "https://scontent-ams3-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/10247239_826866984028483_1194786633566871632_n.jpg?oh=a865d983a6ba6f6eedbcb5715f3834dc&oe=56D4DBB5", ParameterType.UrlSegment);
			//
			//			var response = client.Execute (request);
			//			var content = response.Content; // raw content as string


			var client = new HttpClient();
			var queryString = HttpUtility.ParseQueryString(string.Empty);

			// Request headers
			//			client.DefaultRequestHeaders.Add ("Content-Type", "application/json");
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");

			// Request parameters
			queryString["visualFeatures"] = "All";
			var uri = "https://api.projectoxford.ai/vision/v1/analyses?" + queryString;


			// Request body

			byte[] byteData = Encoding.UTF8.GetBytes("\t\t\t{ \"Url\": \"https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b\"}\n");

			using (var content = new ByteArrayContent(byteData))
			{
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				response = await client.PostAsync(uri, content);
				Console.Write(response);



				var receiveStream = response.Content.ReadAsStringAsync();


				//				foreach (var item in response.) {
				//					item.
				//				}

			}















			//			var clientx = new RestClient ("https://api.projectoxford.ai/vision/v1/analyses?visualFeatures=Face");
			//			var request = new RestRequest (Method.POST);
			//			request.AddHeader ("Content-Type", "application/json"); // adds to POST or URL querystring based on Method
			//			request.AddHeader ("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");
			//
			//			request.AddBody ("url", "https://scontent-ams3-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/10247239_826866984028483_1194786633566871632_n.jpg?oh=a865d983a6ba6f6eedbcb5715f3834dc&oe=56D4DBB5");
			//			var response = clientx.Execute (request);
			//
			//
			//			Console.Write (response);

			//			VisionHelper vision = new VisionHelper ("c37ff7c34db145e9b73cf2630308fb07");
			//
			//
			//			Console.WriteLine ("resim id gir");
			//
			//			string adres = "https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b";
			//
			//			vision.AnalyzeImage (adres);



			//			var client = new RestClient ("https://api.projectoxford.ai/vision/v1/analyses?visualFeatures=All");
			////			var request = new RestRequest ("resource/{id}", Method.POST);
			//			var request = new RestRequest ();
			//
			//			request.Method = Method.POST;
			//
			//			request.AddHeader ("Accept", "application/json");
			//			request.AddHeader ("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");
			//			request.AddParameter ("visualFeatures", "All", ParameterType.QueryString); 
			//
			//


		}









		//
		//		Request URL


		//		HTTP request
		//
		//		POST https://api.projectoxford.ai/vision/v1/analyses?visualFeatures=All HTTP/1.1
		//		Content-Type: application/json
		//		Host: api.projectoxford.ai
		//		Content-Length: 215
		//		Ocp-Apim-Subscription-Key: ••••••••••••••••••••••••••••••••
		//
		//		{ "Url": "https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b"}

		async void XRequest()
		{

			var client = new HttpClient();
			var queryString = HttpUtility.ParseQueryString(string.Empty);

			// Request headers
			//			client.DefaultRequestHeaders.Add ("Content-Type", "application/json");
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");

			// Request parameters
			queryString["visualFeatures"] = "All";
			var uri = "https://api.projectoxford.ai/vision/v1/analyses?" + queryString;

			HttpResponseMessage response;

			// Request body
			byte[] byteData = Encoding.UTF8.GetBytes("{ \"Url\": \"https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b\"}");

			using (var content = new ByteArrayContent(byteData))
			{
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				response = await client.PostAsync(uri, content);
			}


			Console.Write(response);


		}



		async void MakeRequest()
		{
			var client = new HttpClient();
			var queryString = HttpUtility.ParseQueryString(string.Empty);

			// Request headers
			//			client.DefaultRequestHeaders.Add ("Content-Type", "application/json");
			client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "c37ff7c34db145e9b73cf2630308fb07");

			// Request parameters
			queryString["visualFeatures"] = "All";
			var uri = "https://api.projectoxford.ai/vision/v1/analyses?" + queryString;

			HttpResponseMessage response;

			// Request body
			byte[] byteData = Encoding.UTF8.GetBytes("{ \"Url\": \"https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xap1/v/t1.0-9/1385592_556552854393232_774346101_n.jpg?oh=1833921eeea6d5c4abe4778cefb96ba7&oe=56E8FC0D&__gda__=1461257870_5b71538322205a9abc367b6a575f0d8b\"}");

			using (var content = new ByteArrayContent(byteData))
			{
				content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				//				content.Headers.ContentType = new MediaTypeHeaderValue ("application/json");
				response = await client.PostAsync(uri, content);


				Console.Write(response);

			}

		}
	}
}



namespace CSHttpClientSample
{
	static class Program
	{
		static void Main()
		{
			;
			Console.WriteLine("Hit ENTER to exit...");
			Console.ReadLine();
		}


	}
}