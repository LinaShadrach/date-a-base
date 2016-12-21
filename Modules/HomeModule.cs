
using Nancy;
using System.Collections.Generic;
using System;
// using System.Windows.Forms;
using DateABase.Objects;

namespace DateABase
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        return View["index.cshtml",model];
      };
      Post["/sign-up"] =_=>{
        User newUser = new User(Request.Form["new-user-name"], Request.Form["new-user-password"]);
        newUser.Save();
        User.SetCurrentUser(newUser);
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        model.Add("message", "Create new profile");
        model.Add("user", currentUser);
        return View["edit_profile.cshtml", model];
      };

      Post["/sign-in"] = _ =>{
        string userName = Request.Form["user-name"];
        string userPassword = Request.Form["user-password"];
        bool loginStatus = User.CheckLogin(userName, userPassword);

        Dictionary<string, object> model = new Dictionary<string, object>();
        Console.WriteLine("before if " + userName);

        User currentUser = User.FindByUserName(userName);
        if (loginStatus == true)
        {
          User.SetCurrentUser(currentUser);
          model.Add("message", "Welcome!");
          model.Add("state", true);
          model.Add("user", currentUser);
          Console.WriteLine("inside true if " + currentUser.UserName);
        }
        if (loginStatus == false)
        {
          model.Add("message", "Invalid User Name or Password");
          Console.WriteLine("inside false if " + currentUser.UserName);
          return View["index.cshtml", model];
        }
        return View["profile.cshtml", model];
      };

      Get["/user/update"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        model.Add("message", "Edit profile");
        model.Add("user", currentUser);
        return View["edit_profile.cshtml", model];
      };
      Get["/profile/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        User currentUser = User.GetCurrentUser();
        User selectedUser = User.Find(parameters.id);
        model.Add("user", selectedUser);
        bool isUsersProfile = false;
        if (currentUser.Id == parameters.id)
        {
          isUsersProfile = true;
        }
        model.Add("state", isUsersProfile);
        return View["profile.cshtml", model];
      };
      // Patch["/user/update"] = _ => {
      //   User currentUser = User.GetCurrentUser();
      //   currentUser.Edit(Request.Form["user-name"], Request.Form["user-password"], Request.Form["first-name"], Request.Form["last-name"], Request.Form["zip-code"],Request.Form["email"], Request.Form["tag-line"], Request.Form["phone-number"],  Request.Form["about"]);
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   model.Add("message", "Your profile has been updated");
      //   model.Add("user", currentUser);
      //   model.Add("state", true);
      //   return View["profile.cshtml", model];
      // };
      Delete["/user/delete"] = _ => {
        User currentUser = User.GetCurrentUser();
        currentUser.Delete();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("message", "Profile Deleted!");
        return View["index.cshtml"];
      };
      Get["/user/delete/cancel"]=_=>{
          Dictionary<string, object> model = new Dictionary<string, object>();
          User currentUser = User.GetCurrentUser();
          model.Add("user", currentUser);
          return View["profile.cshtml", model];
      };
      Get["/users"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<User> allUsers = User.GetAll();
        model.Add("users", allUsers);
        return View["profiles.cshtml", model];
      };

    }
  }
}
