using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tik4net.Objects;
using tik4net.Objects.Ip.Hotspot;

namespace tik4net.tests
{
    [TestClass]
    public class IpHotspotTest : TestBase
    {
        #region HotspotActive
        [TestMethod]
        public void LoadAllActiveWillNotFail()
        {
            Connection.LoadAll<HotspotActive>();
        }
        #endregion

        #region HotspotUserProfile
        [TestMethod]
        public void ListAllUserProfilesWillNotFail()
        {
            var list = Connection.LoadAll<HotspotUserProfile>().ToList();
        }


        #endregion

        #region HotspotUser
        [TestMethod]
        public void AddSingleUserWillNotFail()
        {
            var rnd = new Random();
            //Create user
            var user = new HotspotUser()
            {
                Name = $"TEST{rnd.Next(999)}",
                LimitUptime = "1:00:00",
                Password = "secretpass",
            };

            Connection.Save(user);
        }

        [TestMethod]
        public void UpdateUserWillNotFail()
        {
            var rnd = new Random();
            //Create user
            var user = new HotspotUser()
            {
                Name = $"TEST{rnd.Next(999)}",
                LimitUptime = "1:00:00",
                Password = "secretpass",
            };
            Connection.Save(user);

            //Update
            user.Disabled = true;
            Connection.Save(user);

            //Cleanup
            Connection.Delete(user);
        }

        [Ignore] //DAF: potentionaly harmfull test
        [TestMethod]
        public void DeleteAllUsersWillNotFail()
        {
            var users = Connection.DeleteAll<HotspotUser>();
        }

        [TestMethod]
        public void AddUserWithProfileWillNotFail()
        {
            string profileName = "TEST " + DateTime.Now.ToString();
            var profile = new HotspotUserProfile()
            {
                Name = profileName,
            };
            Connection.Save(profile);

            var user = new HotspotUser()
            {
                Name = "User for " + profileName,
                Profile = profileName,
                LimitUptime = "1:00:00",
            };
            Connection.Save(user);

            //cleanup
            Connection.Delete(user);
            Connection.Delete(profile);
        }

        [Ignore] //DAF: potentionaly harmfull test
        [TestMethod]
        public void DeleteAllUserProfilesWillNotFail()
        {
            var list = Connection.LoadAll<HotspotUserProfile>();
            Connection.SaveListDifferences(list.Where(l => l.Name == "default") /*list with "default" as expected => delete all others*/, list);
        }
        #endregion

        #region HotspotIpBinding
        [TestMethod]
        public void LoadAllHotspotIpBindingsWillNotFail()
        {
            Connection.LoadAll<HotspotIpBinding>();
        }

        [TestMethod]
        public void CreateAndRemoveHotspotIpBindingsWillNotFail()
        {
            const string ADDRESS = "192.168.168.1";
            var binding = new HotspotIpBinding()
            {
                Address = ADDRESS,
            };

            Connection.Save(binding);
            var loadedBinding = Connection.LoadAll<HotspotIpBinding>().SingleOrDefault(ib => ib.Address == ADDRESS);
            Assert.IsNotNull(loadedBinding);

            Connection.Delete(binding);
        }

        #endregion
    }

}
