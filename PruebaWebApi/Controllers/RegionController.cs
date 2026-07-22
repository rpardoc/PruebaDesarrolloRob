using log4net;
using PruebaWebApi.DTO;
using PruebaWebApi.Interfaces;
using System;
using System.Linq;
using System.Web.Http;


namespace PruebaWebApi.Controllers
{
    [RoutePrefix("api/region")]
    public class RegionController : ApiController
    {

        private readonly IRegionService service;

        private readonly ILog log =
            LogManager.GetLogger(typeof(RegionController));


        public RegionController(
            IRegionService service)
        {
            this.service = service;
        }



        // GET api/region
        // Listado de regiones

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRegiones()
        {
            try
            {
                log.Info("Consultando listado de regiones");


                var regiones =
                    service.ObtenerRegiones();


                log.Info($"Regiones obtenidas correctamente. Cantidad: {regiones.Count()}");


                return Ok(regiones);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener listado de regiones", ex);

                return InternalServerError();
            }
        }



        // GET api/region/1
        // Información de una región

        [HttpGet]
        [Route("{idRegion:int}")]
        public IHttpActionResult GetRegion(
            int idRegion)
        {
            try
            {
                log.Info($"Consultando región. IdRegion: {idRegion}");


                var region =
                    service.ObtenerRegion(idRegion);


                if (region == null)
                {
                    log.Warn($"No existe región con Id: {idRegion}");

                    return NotFound();
                }


                log.Info($"Región encontrada. IdRegion: {idRegion}");


                return Ok(region);
            }
            catch (Exception ex)
            {
                log.Error(
                    $"Error consultando región {idRegion}",
                    ex);

                return InternalServerError();
            }
        }



        // GET api/region/1/comuna

        [HttpGet]
        [Route("{idRegion:int}/comuna")]
        public IHttpActionResult GetComunas(
            int idRegion)
        {
            try
            {
                log.Info(
                    $"Consultando comunas de región {idRegion}");


                var comunas =
                    service.ObtenerComunas(idRegion);


                log.Info(
                    $"Comunas obtenidas. Región: {idRegion}");


                return Ok(comunas);
            }
            catch (Exception ex)
            {
                log.Error(
                    $"Error obteniendo comunas región {idRegion}",
                    ex);

                return InternalServerError();
            }
        }



        // POST api/region/1/comuna

        [HttpPost]
        [Route("{idRegion:int}/comuna")]
        public IHttpActionResult ActualizarComuna(
            int idRegion,
            ActualizarComunaDTO comuna)
        {
            try
            {
                log.Info(
                    $"Actualizando comuna. Región: {idRegion}");


                if (comuna == null)
                {
                    log.Warn("Solicitud recibida sin datos de comuna");

                    return BadRequest(
                        "Datos inválidos");
                }


                bool resultado =
                    service.ActualizarComuna(comuna);


                if (!resultado)
                {
                    log.Warn(
                        $"No fue posible actualizar comuna. Región: {idRegion}");

                    return BadRequest(
                        "No fue posible actualizar");
                }


                log.Info(
                    $"Comuna actualizada correctamente. Región: {idRegion}");


                return Ok(new
                {
                    mensaje = "Comuna actualizada correctamente"
                });
            }
            catch (Exception ex)
            {
                log.Error(
                    $"Error actualizando comuna. Región: {idRegion}",
                    ex);

                return InternalServerError();
            }
        }

    }
}