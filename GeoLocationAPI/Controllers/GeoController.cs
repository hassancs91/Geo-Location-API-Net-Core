using GeoLocationAPI.Models;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {

        [HttpGet("[action]/{ipAddress}")]
        public IActionResult GetCountry(string ipAddress)
        {
            //Change Path Here!!!!
            using (var reader = new DatabaseReader(@"E:\LearnWithHasan\Projects\C#\Geo Location API\Demo Project\db\geo.mmdb"))
            {
                var response = reader.Country(ipAddress);

                var geoLocation = new GeoClass();
                geoLocation.countryName = response.Country.Name;
                geoLocation.countryIsoCode = response.Country.IsoCode;
                geoLocation.IsInEuropeanUnion = response.Country.IsInEuropeanUnion;

                return StatusCode(StatusCodes.Status200OK, geoLocation);

            }


        }



    }
}
