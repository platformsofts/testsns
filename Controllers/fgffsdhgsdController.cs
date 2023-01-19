using Microsoft.AspNetCore.Mvc;

namespace testteee.Controllers;

[ApiController]
public class fgffsdhgsdController : ControllerBase
{
    private readonly ILogger<fgffsdhgsdController> _logger;
    public fgffsdhgsdController(ILogger<fgffsdhgsdController> logger)
    {
        _logger = logger;
    }
    [HttpGet("testeeddf")]
    public IActionResult ReturnaString()
    {
        return NotFound("Ola Mundo");
    }

    [HttpPost("testeeddf")]
    public String SNSSubscriptionPost(String id = "")
    {
        try
        {
            Console.WriteLine("Chegei--------------");
            Console.WriteLine("Chegei-------------");
            // var jsonData = "";
            // Stream req = Request.;
            // req.Seek(0, System.IO.SeekOrigin.Begin);
            // String json = new StreamReader(req).ReadToEnd();
            // var sm = Amazon.SimpleNotificationService.Util.Message.ParseMessage(json);
            // if (sm.Type.Equals("SubscriptionConfirmation")) //for confirmation
            // {
            //     // _logger.Info("Received Confirm subscription request");
            //     // if (!string.IsNullOrEmpty(sm.SubscribeURL))
            //     // {
            //     //     var uri = new Uri(sm.SubscribeURL);
            //     //     _logger.Info("uri:" + uri.ToString());
            //     //     var baseUrl = uri.GetLeftPart(System.UriPartial.Authority);
            //     //     var resource = sm.SubscribeURL.Replace(baseUrl, "");
            //     //     var response = new RestClient
            //     //     {
            //     //         BaseUrl = new Uri(baseUrl),
            //     //     }.Execute(new RestRequest
            //     //     {
            //     //         Resource = resource,
            //     //         Method = Method.GET,
            //     //         RequestFormat = RestSharp.DataFormat.Xml
            //     //     });
            //     // }
            // }
            // else // For processing of messages
            // {
            //     //_logger.Info("Message received from SNS:" + sm.TopicArn);
            //     //dynamic message = JsonConvert.DeserializeObject(sm.MessageText);
            //     //_logger.Info("EventTime : " + message.detail.eventTime);
            //     //_logger.Info("EventName : " + message.detail.eventName);
            //     //_logger.Info("RequestParams : " + message.detail.requestParameters);
            //     //_logger.Info("ResponseParams : " + message.detail.responseElements);
            //     //_logger.Info("RequestID : " + message.detail.requestID);
            // }

            //do stuff
            return "Success";
        }
        catch (Exception ex)
        {
            //_logger.Info("failed");
            return "";
        }
    }
}