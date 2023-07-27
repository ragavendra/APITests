﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text.Json;

namespace AppName
{
    public class SomeAppTest : TestFixture
    {
		
        [TestCase(TestName = "Member settings workflow"), Order(0)]
        public void MemberSettingsWorkflow()
        {
            string memberId = DateTime.Now.ToString("MMddyyyy_HHmmss");

            SomeApp someapp = new SomeApp();

            someapp.GetMembersSettings();
            var respo = someapp.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var members = JsonConvert.DeserializeObject<List<Member>>(respo.response);
            var members = JsonSerializer.Deserialize<List<Models.Member>>(respo.response);
            //JObject resp = JObject.Parse(respo.response);

            //check if member already exists in the system
            foreach (var member in members)
                Assert.AreNotEqual(memberId, member.identification, $"Member id - {memberId} exists in the system");

            //add member to the system - use POST call
            someapp.SaveMemberToSettings(memberId, "First", "Last", "604 111 1111");
            respo = someapp.Post();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");

            //var member = JsonConvert.DeserializeObject<List<Member>>(respo.response);

            someapp.GetMembersSettings();
            respo = someapp.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            //members = JsonConvert.DeserializeObject<List<Member>>(respo.response);
             members = JsonSerializer.Deserialize<List<Models.Member>>(respo.response);

            bool flag = false;

            //check if member exists in the system
            foreach (var member in members)
            {
                if (member.identification == null)
                    continue;
                if (member.identification.Equals(memberId))
                {
                    flag = true;
                    break;
                }
            }

            Assert.True(flag, $"Member id - {memberId} does not exist in the system after POST");

            //delete member
            someapp.DeleteMemberFromSettings(memberId);
            respo = someapp.Delete();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");


            someapp.GetMembersSettings();
            respo = someapp.Get();
            Assert.AreEqual(200, (int) respo.status, "Status code is not 200");
            //resp = JObject.Parse(respo.response);
            members = JsonSerializer.Deserialize<List<Models.Member>>(respo.response);

            flag = false;

            //check if member does not exists in the system
            foreach (var member in members)
            {
                if (member.identification == null)
                    continue;
                if (member.identification.Equals(memberId))
                {
                    flag = true;
                    break;
                }
            }

            Assert.True(!flag, $"Member id - {memberId} exists in the system after DELETE");


        }


    }
}