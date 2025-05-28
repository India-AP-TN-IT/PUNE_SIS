using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;


using Newtonsoft.Json;

namespace Ax.SIS.SD.UI.EINV
{
    public class EInvoiceMapper
    {
        private string Url = "http://sis.seoyonehap.com/sisinterface/api/";
        // The following URL is used for development purpose
        //private string DirectAPIAccessUrl = "http://localhost:58469/api/";
        // The following URL is used for creating IRN in live environment.
        private string DirectAPIAccessUrl = "http://sis.seoyonehap.com/siseinvoicedirectapi/api/";

        public MessageEntity GenerateIRN(IRNRequestModel ObjIRNRequestModel)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(ObjIRNRequestModel);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Url + "sis/SyncData", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        responseObj = JsonConvert.DeserializeObject<MessageEntity>(result);
                    }
                }
            }
            catch (Exception)
            {

            }

            return responseObj;
        }

        public MessageEntity GenerateJSONFile(IRNRequestModel ObjIRNRequestModel)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(ObjIRNRequestModel);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Url + "sis/ManualIRNJsonGeneration", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        responseObj = JsonConvert.DeserializeObject<MessageEntity>(result);
                    }
                }
            }
            catch (Exception)
            {

            }

            return responseObj;
        }

        public MessageEntity UpdateInvoice(GenerateIRNResponseEntity ObjIRNResponseModel)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(ObjIRNResponseModel);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Url + "sis/ManualUpdateIRN", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        responseObj = JsonConvert.DeserializeObject<MessageEntity>(result);
                    }
                }
            }
            catch (Exception)
            {

            }

            return responseObj;
        }


        public MessageEntity FailedInvoiceUpdate(GenerateIRNResponseEntity ObjIRNResponseModel)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(ObjIRNResponseModel);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Url + "sis/ManualUpdateError", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        responseObj = JsonConvert.DeserializeObject<MessageEntity>(result);
                    }
                }
            }
            catch (Exception)
            {

            }

            return responseObj;
        }

        public MessageEntity GenerateIRNAndEWayBillUsingDirectAPIAccess(IRNRequestModel IRNRequest)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(IRNRequest);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "IRNOperations/GenerateIRN", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<ResultEntity>(result);

                        responseObj.Message = res.Result.Message;
                        responseObj.Status = res.Result.Status;
                    }
                }
            }
            catch (Exception)
            {

            }

            return responseObj;
        }

        public MessageEntity GenerateEWayBillUsingDirectAPIAccess(CreateEWayBillRequestEntity CreateEWayBillRequest)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(CreateEWayBillRequest);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "EWayBillOperations/GenerateEWayBill", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<ResultEntity>(result);
                        responseObj.Message = res.Result.Message;
                        responseObj.Status = res.Result.Status;
                    }
                }
            }
            catch (Exception)
            {
            }

            return responseObj;
        }

        public MessageEntity CancelEWayBillUsingDirectAPIAccess(CancelEWayBillRequestEntity cancelEWayBillRequest)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(cancelEWayBillRequest);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "EWayBillOperations/CancelEWayBill", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<ResultEntity>(result);
                        responseObj.Message = res.Result.Message;
                        responseObj.Status = res.Result.Status;
                    }
                }
            }
            catch (Exception)
            {
            }

            return responseObj;
        }

        public MessageEntity CancelIRNUsingDirectAPIAccess(CancelIRNDirectAPIAccess cancelIRN)
        {
            MessageEntity responseObj = new MessageEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(cancelIRN);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "IRNOperations/CancelIRN", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<ResultEntity>(result);
                        responseObj.Message = res.Result.Message;
                        responseObj.Status = res.Result.Status;
                    }
                }
            }
            catch (Exception)
            {
            }

            return responseObj;
        }

        public IRNDetailsEntity GetIRNDetails(GetIRNDetailsRequestEntity IRNDetails)
        {
            IRNDetailsEntity IRNDetailsToBeReturn = new IRNDetailsEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(IRNDetails);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "IRNOperations/GetIRNDetails", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<GetIRNDetailsResultEntity>(result);
                        IRNDetailsToBeReturn = res.Result;
                    }
                }
            }
            catch (Exception)
            {
            }

            return IRNDetailsToBeReturn;
        }

        public EWayBillEntity GetEWayBillDetails(GetEWayBillDetailsRequestEntity EWayBill)
        {
            EWayBillEntity EWayBillReturn = new EWayBillEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromMinutes(10);
                    string inputJson = JsonConvert.SerializeObject(EWayBill);
                    HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(DirectAPIAccessUrl + "EWayBillOperations/GetEWayBillDetails", inputContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();
                        string result = readTask.Result;
                        var res = JsonConvert.DeserializeObject<GetEWayBillDetailsResultEntity>(result);
                        EWayBillReturn = res.Result;
                    }
                }
            }
            catch (Exception)
            {
            }

            return EWayBillReturn;
        }

    }
}
