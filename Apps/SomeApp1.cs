
namespace ApiTests.Apps
{
    public class SomeApp1 : Rest
    {
        
        private string serverName = Constants.eotServerName;
        private const string protocol = Constants.protocol;

        public SomeApp1(string routeFilter = "")
        {
            if (routeFilter != "")
                _url = $"{protocol}://{serverName}/someapp1/api/SomeApp1?routeFilter={routeFilter}";
            else
                _url = $"{protocol}://{serverName}/someapp1/api/SomeApp1";
        }

        public void SomeApp1History(string dateTime)
        {
            _url = $"{protocol}://{serverName}/someapp1/api/SomeApp1/History/{dateTime}";
        }

        public void SomeApp1TimeLapse(string fromDateTime, string toDateTime, string intervalInSeconds)
        {
            _url = $"{protocol}://{serverName}/someapp1/api/SomeApp1/timelapse/{fromDateTime}/{toDateTime}/{intervalInSeconds}";
        }

        public void Status(string requestId = "")
        {
            _url = $"{protocol}://{serverName}/someapp1/api/Status?requestId={requestId}";
        }


        public void GetScheduleAndBuses(string stopNo, string count, string timeFrame)
        {
        }

    }
}