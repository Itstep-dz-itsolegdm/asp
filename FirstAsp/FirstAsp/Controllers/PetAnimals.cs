using Microsoft.AspNetCore.Mvc;

namespace FirstAsp.Controllers;

public class PetAnimalsController : Controller
{
    public string Cat()
    {
        return "meow";
    }
    public string dog()
    {
        return "woof";
    }
}