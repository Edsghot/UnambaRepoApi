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
            message = "ok",
            success = true,
            data = new object[]
            {
                // Comprobante correcto de combustible
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F001",
                    NumCompra = "0001234567",
                    DocumentoProveedor = "20554545743",
                    TipoDocumento = 2,
                    RazonSocial = "REPSOL COMERCIAL S.A.C.",
                    Sucursal = "Av. Javier Prado Este 1234, San Isidro, Lima",
                    FechaEmision = "2024-10-24",
                    FechaVencimiento = "2024-11-11",
                    Moneda = "N",
                    Condicion = "R",
                    Observacion = "Compra de combustibles",
                    Scop = "1234567890",
                    TotalGravadas = 150000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 27000.00m,
                    TotalPagar = 177000.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "1001",
                            serie = "SERIE001",
                            Tieneserie = true,
                            cantidad = 5000,
                            descripcion = "Gasolina 95",
                            API = 35.00m,
                            temp = 20.0m,
                            precioUnitario = 30.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 5400.00m,
                            Tratamiento = 10,
                            subTotal = 150000.00m,
                            total = 177000.00m
                        },
                        new
                        {
                            codigo = "1002",
                            serie = "SERIE002",
                            Tieneserie = true,
                            cantidad = 3000,
                            descripcion = "Diesel B5",
                            API = 32.00m,
                            temp = 20.0m,
                            precioUnitario = 25.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 4500.00m,
                            Tratamiento = 10,
                            subTotal = 75000.00m,
                            total = 88500.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-123456",
                    FechaEmisionReferencia = "2024-10-22",
                    PlacaTransportista = "ABC-123",
                    LicenciaTransportista = "L-12345678",
                    MarcaTransportista = "VOLVO"
                },
                // Comprobante correcto de productos de mercado
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "M001",
                    NumCompra = "0002233445",
                    DocumentoProveedor = "20678945612",
                    TipoDocumento = 2,
                    RazonSocial = "SUPERMERCADOS PERUANOS S.A.",
                    Sucursal = "",
                    FechaEmision = "2024-10-25",
                    FechaVencimiento = "2024-11-10",
                    Moneda = "S",
                    Condicion = "C",
                    Observacion = "Compra de víveres",
                    Scop = "",
                    TotalGravadas = 1200.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 216.00m,
                    TotalPagar = 1416.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "P001",
                            serie = "",
                            Tieneserie = false,
                            cantidad = 10,
                            descripcion = "Arroz 1kg",
                            precioUnitario = 2.50m,
                            tieneIGV = 1,
                            IGV = 4.50m,
                            subTotal = 25.00m,
                            total = 29.50m
                        },
                        new
                        {
                            codigo = "P002",
                            serie = "",
                            Tieneserie = false,
                            cantidad = 5,
                            descripcion = "Aceite 1L",
                            precioUnitario = 10.00m,
                            tieneIGV = 1,
                            IGV = 9.00m,
                            subTotal = 50.00m,
                            total = 59.00m
                        }
                    }
                },
                // Comprobante con errores
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F003",
                    NumCompra = "0001234569",
                    DocumentoProveedor = "205545457432055454574320554545743", // Error
                    TipoDocumento = 2,
                    RazonSocial = "PRIMAX S.A.",
                    Sucursal = "Av. La Marina 456, San Miguel, Lima",
                    FechaEmision = "2024-10-24",
                    Scop = "123456789012", // Error
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "P004", cantidad = 10, descripcion = "Pan 1kg", precioUnitario = 5.00m,
                            total = 50.00m
                        } 
                    }
                },
                // Comprobante con 5 productos
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "M002",
                    NumCompra = "0002233446",
                    DocumentoProveedor = "20987654321",
                    TipoDocumento = 2,
                    RazonSocial = "MERCADO CENTRAL",
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "P004", cantidad = 10, descripcion = "Pan 1kg", precioUnitario = 5.00m,
                            total = 50.00m
                        },
                        new
                        {
                            codigo = "P005", cantidad = 2, descripcion = "Pollo", precioUnitario = 12.00m,
                            total = 24.00m
                        },
                        new
                        {
                            codigo = "P006", cantidad = 1, descripcion = "Carne 1kg", precioUnitario = 15.00m,
                            total = 15.00m
                        },
                        new
                        {
                            codigo = "P007", cantidad = 3, descripcion = "Frutas variadas", precioUnitario = 8.00m,
                            total = 24.00m
                        },
                        new
                        {
                            codigo = "P008", cantidad = 6, descripcion = "Bebidas gaseosas", precioUnitario = 6.00m,
                            total = 36.00m
                        }
                    }
                }
            }
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