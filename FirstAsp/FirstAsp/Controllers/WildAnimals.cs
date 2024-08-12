using Microsoft.AspNetCore.Mvc;

namespace FirstAsp.Controllers;

public class WildAnimalsController : Controller
{
    public string Wolf()
    {
        return "wooo";
    }
    public string Lion()
    {
        return "rawr";
    }
}