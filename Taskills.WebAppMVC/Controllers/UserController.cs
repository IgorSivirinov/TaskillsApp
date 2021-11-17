using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskills.WebAppMVC.Models.CosmosDb;
using Taskills.WebAppMVC.Models.CosmosDb.DbModels;

namespace Taskills.WebAppMVC.Controllers;

[Authorize]
public class UserController: Controller
{

}