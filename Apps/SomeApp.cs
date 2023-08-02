using ApiTests.Models;
using System.Text.Json;

namespace ApiTests.Apps
{
    public class SomeApp : Rest
    {
        
        private string _serverName = Constants.eotServerName;

        private readonly string _protocol = Constants.protocol;

        private readonly string version = 1.ToString();

        //GET calls
        public void GetAllSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/All";
        }
		
		//search incident URL gen multiple params
        public void GetIncidentReportSearch(string ss = "", string sk = "", string fd = "", string td = "", string ui = "")
        {
            int iIndex = 0;

            //"ss=abc&sk=xyz&fd=123&td=235&ui=jjj"

            if ((ss == "") && (sk == "") && (fd == "") && (td == "") && (ui == ""))
            {
                _url = $"{_protocol}://{_serverName}/v{version}/IncidentReport/list";
                return;
            }

            if (ss != "")
            {
                _url = _url + $"ss={ss}";
                iIndex++;
            }

            if (sk != "")
            {
                if (iIndex > 0)
                    _url = _url + "&";

                _url = _url + $"sk={sk}";
                iIndex++;
            }

            if (fd != "")
            {
                if (iIndex > 0)
                    _url = _url + "&";

                _url = _url + $"fd={fd}";
            }

            if (td != "")
            {
                if (iIndex > 0)
                    _url = _url + "&";

                _url = _url + $"td={td}";
            }

            if (ui != "")
            {
                if (iIndex > 0)
                    _url = _url + "&";

                _url = _url + $"ui={ui}";
            }

            _url = $"{_protocol}://{_serverName}/v{version}/IncidentReport/list?" + _url;

        }


        public void GetCarsSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Cars";
        }

        public void GetMembersSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members";
        }

        public void GetPatrolAreasSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolAreas";
        }

        public void GetPatrolHubToSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolHubs";
        }

        public void GetPatrolRolesSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Roles";
        }

        public void GetShiftDefaultHoursSettings()
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/ShiftDefaultHours";
        }

        public void GetShiftsByDate(string date)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Shifts/{date}";
        }

        public void GetShiftsWithSettingsByDate(string date)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/ShiftsWithSettings/{date}";
        }

        //POST calls
        public void SaveMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members";

            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
            Member person = new Member();
            person.identification = identification;
            person.firstName = firstName;
            person.lastName = lastName;
            person.phone = phone;
            _message = JsonSerializer.Serialize(person);
        }

        public void UpdateShift(string name, string startHour, string endHour)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            _message = JsonSerializer.Serialize(shift);
        }

        public void UpdateShiftDefaultHoursToSettings(string name, string startHour, string endHour)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members";

            ShiftHour shift = new ShiftHour();
            shift.name = name;
            shift.startHour = startHour;
            shift.endHour = endHour;

            _message = JsonSerializer.Serialize(shift);
        }

        //PUT calls
        public void AddMemberToSettings(string identification, string firstName, string lastName, string phone)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members";

            //sMessage = $"\"identification\": {identification},\"firstName\": {firstName},\"lastName\": {lastName},\"phone\": {phone}\"";
            Member person = new Member();
            person.identification = identification;
            person.firstName = firstName;
            person.lastName = lastName;
            person.phone = phone;
            _message = JsonSerializer.Serialize(person);
        }

        public void AddCarToSettings(string car)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Cars/{car}";

            _message = JsonSerializer.Serialize(car);
        }

        public void AddPatrolAreaToSettings(string area)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolAreas/{area}";

            Member person = new Member();
            _message = JsonSerializer.Serialize(person);
        }

        public void AddPatrolHubToSettings(string hub)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolHubs/{hub}";

            Member person = new Member();
            _message = JsonSerializer.Serialize(person);
        }

        public void AddRoleToSettings(string role)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Roles/{role}";

            Member person = new Member();
            _message = JsonSerializer.Serialize(person);
        }

        public void AddShift(string role)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Shifts/Add";

            Member person = new Member();
            _message = JsonSerializer.Serialize(person);
        }

        //DELETE calls

        public void DeleteCarFromSettings(string car)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Cars/{car}";
        }

        public void DeleteMemberFromSettings(string identification)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Members/{identification}";
        }

        public void DeletePatrolAreaFromSettings(string area)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolAreas/{area}";
        }

        public void DeletePatrolHubFromSettings(string hub)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/PatrolHubs/{hub}";
        }

        public void DeleteRoleFromSettings(string role)
        {
            _url = $"{_protocol}://{_serverName}/someapp/api/someapp/Settings/Roles/{role}";
        }


    }
}
