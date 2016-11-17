using Nancy;
using System.Collections.Generic;
using Tamagochi.Objects;
using System;

namespace Tamagochi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>{
        return View["index.cshtml"];
      };
      Get["/new-friend"] = _ =>{
        return View["toma_form.cshtml"];
      };

      Post["/new-friend"] = _ =>
      {
        Pet newPet = new Pet(Request.Form["name"]);
        return View["/life_of_friend.cshtml", newPet];
      };
      Post["/{action}"] = parameters =>{
        List<Pet> allPets = Pet.GetAll();
        var thisPet = allPets[0];
        bool dead = thisPet.PetIsDead();

        if (parameters.action == "time"){
          thisPet.ElapsedTime();
        }
        if (parameters.action == "play" && !dead){
          thisPet.PlayPet();
        }
        if (parameters.action == "feed" && !dead){
          thisPet.FeedPet();
        }
        if (parameters.action == "sleep" && !dead){
          thisPet.BedPet();
        }
        if(dead == true)
        {
        //  allPets.ClearAll();
          return View["/pet_is_dead.cshtml"];
        }
        return View["/life_of_friend.cshtml", thisPet];

        };

      }
    }
  }
