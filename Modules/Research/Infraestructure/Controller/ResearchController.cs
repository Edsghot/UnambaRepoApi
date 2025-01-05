using Microsoft.AspNetCore.Mvc;
using UnambaRepoApi.Modules.Research.Application.Port;
using UnambaRepoApi.Modules.Teacher.Application.Port;

namespace UnambaRepoApi.Modules.Research.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class ResearchController : ControllerBase
{
    private readonly IResearchInputPort _researchInputPort;
    private readonly IResearchOutPort _researchOutPort;

    public ResearchController(IResearchInputPort inputPort, IResearchOutPort outPort)
    {
        _researchInputPort = inputPort;
        _researchOutPort = outPort;
    }

    [HttpGet("GetAllResearchProject")]
    public async Task<IActionResult> GetAllResearchProject()
    {
        await _researchInputPort.GetAllResearchProject();
        var response = _researchOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetAllScientificArticle")]
    public async Task<IActionResult> GetAllScientificArticle()
    {
        await _researchInputPort.GetAllScientificArticle();
        var response = _researchOutPort.GetResponse;

        return Ok(response);
    }
    
    [HttpGet("pecanoSrc")]
    public IActionResult PecanoSrc()
    {
         var response = new
            {
                NomTipoDocumento = "Factura Electronica",
                AbrevTipoDocumento = "FA",
                SerieCompra = "F447",
                NumCompra = "0145575",
                DocumentoProveedor = "20554545743",
                TipoDocumento = 2,
                RazonSocial = "CORPORACION PRIMAX S.A.",
                Sucursal = "Av Circunvalación del Club Golf Los Incas N° 134, Edificio Panorama Torre 1 Piso 18",
                FechaEmision = "2024-10-24",
                FechaVencimiento = "2024-11-11",
                Moneda = "N",
                Condicion = "R",
                Observacion = "Compra de combustible",
                Scop = "12427335754",
                TotalGravadas = 97367.27m,
                TotalExoneradas = 0.0m,
                TotalOtrosTributos = 0.0m,
                TotalPercepcion = 1148.93m,
                TotalIGV = 17526.11m,
                TotalPagar = 116042.31m,
                Compras = new[]
                {
                    new
                    {
                        codigo = "40002024",
                        serie = "ABC123",
                        Tieneserie = true,
                        cantidad = 9100,
                        descripcion = "Endura Super Diesel B5 S50",
                        API = 36.90m,
                        temp = 15.0m,
                        precioUnitario = 97367.27m,
                        Fise = 97367.27m,
                        dscto = 0.0m,
                        ISC = 0.0m,
                        tieneIGV = 1,
                        IGV = 17526.11m,
                        Tratamiento = 10,
                        subTotal = 97367.27m,
                        total = 114893.38m
                    }
                },
                TipoDocReferencia = "Guía de Remisión",
                CorrelativoReferencia = "1-6306405",
                FechaEmisionReferencia = "2024-10-22",
                PlacaTransportista = "ARI-836",
                LicenciaTransportista = "H-43381852",
                MarcaTransportista = "HYUNDAI"
            };

            return Ok(response);
    }


    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ResearchController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ResearchController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}