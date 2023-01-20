using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;


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
            var jsonData = "";
            _logger.LogInformation("Cheguei");
            Stream req = Request.Body;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            String json = new StreamReader(req).ReadToEnd();
            var sm = Amazon.SimpleNotificationService.Util.Message.ParseMessage(json);
            if (sm.Type.Equals("SubscriptionConfirmation")) //for confirmation
            {
                _logger.LogInformation("Received Confirm subscription request");
               
                if (!string.IsNullOrEmpty(sm.SubscribeURL))
                {
                    var uri = new Uri(sm.SubscribeURL);
                    _logger.LogInformation("uri:" + uri.ToString());
                    var baseUrl = uri.GetLeftPart(System.UriPartial.Authority);
                    var resource = sm.SubscribeURL.Replace(baseUrl, "");
                    var response = new RestClient(baseUrl)
                      .Execute(new RestRequest
                    {
                        Resource = resource,
                        Method = Method.Get,
                        RequestFormat = RestSharp.DataFormat.Xml
                    });
                }
            }
            else // For processing of messages
            {
                _logger.LogInformation("Message received from SNS:" + sm.TopicArn);
                dynamic message = JsonConvert.DeserializeObject(sm.MessageText);
                _logger.LogInformation($"EventTime : {message.detail.eventTime}");
                _logger.LogInformation($"EventName : {message.detail.eventName}");
                _logger.LogInformation($"RequestParams : {message.detail.requestParameters}"  );
                _logger.LogInformation($"ResponseParams : {message.detail.responseElements}");
                _logger.LogInformation($"RequestID : {message.detail.requestID}" );
            }

//do stuff
            return "Success";
        }
        catch (Exception ex)
        {
            _logger.LogInformation("failed");
            return "";
        }
    }
}