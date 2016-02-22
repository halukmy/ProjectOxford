////
//// Copyright (c) Microsoft. All rights reserved.
//// Licensed under the MIT license.
////
//// Project Oxford: http://ProjectOxford.ai
////
//// ProjectOxford SDK Github:
//// https://github.com/Microsoft/ProjectOxfordSDK-Windows
////
//// Copyright (c) Microsoft Corporation
//// All rights reserved.
////
//// MIT License:
//// Permission is hereby granted, free of charge, to any person obtaining
//// a copy of this software and associated documentation files (the
//// "Software"), to deal in the Software without restriction, including
//// without limitation the rights to use, copy, modify, merge, publish,
//// distribute, sublicense, and/or sell copies of the Software, and to
//// permit persons to whom the Software is furnished to do so, subject to
//// the following conditions:
////
//// The above copyright notice and this permission notice shall be
//// included in all copies or substantial portions of the Software.
////
//// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
//// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
////

//using System;
//using System.IO;
//using System.Text;

//using Microsoft.ProjectOxford.Vision;
//using Microsoft.ProjectOxford.Vision.Contract;

//namespace Microsoft.ProjectOXford.Vision
//{


//	/// <summary>
//	/// The class is used to access vision APIs.
//	/// </summary>
//	public class VisionHelper
//	{
//		/// <summary>
//		/// The vision service client.
//		/// </summary>
//		private readonly IVisionServiceClient visionClient;

//		/// <summary>
//		/// Initializes a new instance of the <see cref="VisionHelper"/> class.
//		/// </summary>
//		/// <param name="subscriptionKey">The subscription key.</param>
//		public VisionHelper (string subscriptionKey)
//		{
//			this.visionClient = new VisionServiceClient (subscriptionKey);
//		}

//		/// <summary>
//		/// Analyze the given image.
//		/// </summary>
//		/// <param name="imagePathOrUrl">The image path or url.</param>
//		public void AnalyzeImage (string imagePathOrUrl)
//		{
////			this.ShowInfo ("Analyzing");
//			AnalysisResult analysisResult = null;

//			string resultStr = string.Empty;
//			try {
//				if (File.Exists (imagePathOrUrl)) {
//					using (FileStream stream = File.Open (imagePathOrUrl, FileMode.Open)) {
//						analysisResult = this.visionClient.AnalyzeImageAsync (stream).Result;
//					}
//				} else if (Uri.IsWellFormedUriString (imagePathOrUrl, UriKind.Absolute)) {
//					analysisResult = this.visionClient.AnalyzeImageAsync (imagePathOrUrl).Result;
//				} else {
////					this.ShowError ("Invalid image path or Url");
//				}
//			} catch (ClientException e) {
//				if (e.Error != null) {
////					this.ShowError (e.Error.Message);
//				} else {
////					this.ShowError (e.Message);
//				}

//				return;
//			} catch (Exception) {
////				this.ShowError ("Some error happened.");
//				return;
//			}

//			this.ShowAnalysisResult (analysisResult);
//		}

//		private void ShowAnalysisResult (AnalysisResult result)
//		{
//			if (result == null) {
//				Console.WriteLine ("null");
//				return;
//			}

//			if (result.Metadata != null) {
//				Console.WriteLine ("Image Format : " + result.Metadata.Format);
//				Console.WriteLine ("Image Dimensions : " + result.Metadata.Width + " x " + result.Metadata.Height);
//			}

//			if (result.ImageType != null) {
//				string clipArtType;
//				switch (result.ImageType.ClipArtType) {
//				case 0:
//					clipArtType = "0 Non-clipart";
//					break;
//				case 1:
//					clipArtType = "1 ambiguous";
//					break;
//				case 2:
//					clipArtType = "2 normal-clipart";
//					break;
//				case 3:
//					clipArtType = "3 good-clipart";
//					break;
//				default:
//					clipArtType = "Unknown";
//					break;
//				}
//				Console.WriteLine ("Clip Art Type : " + clipArtType);

//				string lineDrawingType;
//				switch (result.ImageType.LineDrawingType) {
//				case 0:
//					lineDrawingType = "0 Non-LineDrawing";
//					break;
//				case 1:
//					lineDrawingType = "1 LineDrawing";
//					break;
//				default:
//					lineDrawingType = "Unknown";
//					break;
//				}
//				Console.WriteLine ("Line Drawing Type : " + lineDrawingType);
//			}


//			if (result.Adult != null) {
//				Console.WriteLine ("Is Adult Content : " + result.Adult.IsAdultContent);
//				Console.WriteLine ("Adult Score : " + result.Adult.AdultScore);
//				Console.WriteLine ("Is Racy Content : " + result.Adult.IsRacyContent);
//				Console.WriteLine ("Racy Score : " + result.Adult.RacyScore);
//			}

//			if (result.Categories != null && result.Categories.Length > 0) {
//				Console.WriteLine ("Categories : ");
//				foreach (var category in result.Categories) {
//					Console.Write ("   Name : " + category.Name);
//					Console.WriteLine ("; Score : " + category.Score);
//				}
//			}

//			if (result.Faces != null && result.Faces.Length > 0) {
//				Console.WriteLine ("Faces : ");
//				foreach (var face in result.Faces) {
//					Console.Write ("   Age : " + face.Age);
//					Console.Write ("; Gender : " + face.Gender);
//				}
//			}

//			if (result.Color != null) {
//				Console.WriteLine ("AccentColor : " + result.Color.AccentColor);
//				Console.WriteLine ("Dominant Color Background : " + result.Color.DominantColorBackground);
//				Console.WriteLine ("Dominant Color Foreground : " + result.Color.DominantColorForeground);

//				if (result.Color.DominantColors != null && result.Color.DominantColors.Length > 0) {
//					Console.Write ("Dominant Colors : ");
//					foreach (var color in result.Color.DominantColors) {
//						Console.Write (color + " ");
//					}
//				}
//			}

//			//			Console.ResetColor ();
//		}
//	}
//}

