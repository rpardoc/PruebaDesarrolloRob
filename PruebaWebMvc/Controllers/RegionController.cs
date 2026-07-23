using PruebaWebMvc.Dto;
using PruebaWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaWebMvc.Controllers
{
    public class RegionController : Controller
    {
        private readonly ApiService api;


        public RegionController()
        {
            api = new ApiService();
        }



        public async Task<ActionResult> Index()
        {

            List<RegionDTO> regiones =
                await api.Get<List<RegionDTO>>(
                    "region");

            return View(regiones);

        }

        public async Task<ActionResult> Comunas(int idRegion)
        {
            List<ComunaDTO> comunas =
                await api.Get<List<ComunaDTO>>(
                    $"region/{idRegion}/comuna");


            return View(comunas);
        }

        // GET: Region/EditarComuna
        public async Task<ActionResult> EditarComuna(
            int idRegion,
            int idComuna)
        {
            try
            {

                ComunaDTO comuna =
                    await api.Get<ComunaDTO>(
                        $"region/{idRegion}/comuna/{idComuna}");


                if (comuna == null)
                {
                    return HttpNotFound();
                }


                return View(comuna);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditarComuna(
      int idRegion,
      ComunaDTO comuna)
        {
            if (comuna == null)
            {
                throw new Exception("Comuna llegó NULL");
            }


            if (!ModelState.IsValid)
            {
                return View(comuna);
            }


            var resultado =
                await api.Post<dynamic>(
                    $"region/{idRegion}/comuna",
                    new
                    {
                        IdComuna = comuna.IdComuna,
                        NombreComuna = comuna.NombreComuna,
                        Superficie = comuna.Superficie,
                        Poblacion = comuna.Poblacion,
                        Densidad = comuna.Densidad
                    });


            return RedirectToAction(
                "Comunas",
                new
                {
                    idRegion = idRegion
                });
        }
    }
}