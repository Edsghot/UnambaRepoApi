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
            data = new[]
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
                    Sucursal = null, // Sin sucursal
                    FechaEmision = "2024-10-25",
                    FechaVencimiento = "2024-11-10",
                    Moneda = "S",
                    Condicion = "C",
                    Observacion = "Compra de víveres",
                    Scop = null,
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
                            serie = null,
                            Tieneserie = false,
                            cantidad = 10,
                            descripcion = "Arroz 1kg",
                            API = null,
                            temp = null,
                            precioUnitario = 2.50m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 4.50m,
                            Tratamiento = null,
                            subTotal = 25.00m,
                            total = 29.50m
                        },
                        new
                        {
                            codigo = "P002",
                            serie = null,
                            Tieneserie = false,
                            cantidad = 5,
                            descripcion = "Aceite 1L",
                            API = null,
                            temp = null,
                            precioUnitario = 10.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 9.00m,
                            Tratamiento = null,
                            subTotal = 50.00m,
                            total = 59.00m
                        },
                        new
                        {
                            codigo = "P003",
                            serie = null,
                            Tieneserie = false,
                            cantidad = 12,
                            descripcion = "Leche 1L",
                            API = null,
                            temp = null,
                            precioUnitario = 3.50m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 7.56m,
                            Tratamiento = null,
                            subTotal = 42.00m,
                            total = 49.56m
                        }
                    },
                    TipoDocReferencia = null,
                    CorrelativoReferencia = null,
                    FechaEmisionReferencia = null,
                    PlacaTransportista = null,
                    LicenciaTransportista = null,
                    MarcaTransportista = null
                },
                // Comprobante correcto adicional
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F004",
                    NumCompra = "0002233446",
                    DocumentoProveedor = "20554548765",
                    TipoDocumento = 2,
                    RazonSocial = "CORPORACION PRIMAX S.A.",
                    Sucursal = "Av. Los Olivos 345, Lima",
                    FechaEmision = "2024-11-01",
                    FechaVencimiento = "2024-11-30",
                    Moneda = "S",
                    Condicion = "R",
                    Observacion = "Compra de combustibles y aceites",
                    Scop = "9876543210",
                    TotalGravadas = 250000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 45000.00m,
                    TotalPagar = 295000.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "4001",
                            serie = "SERIE007",
                            Tieneserie = true,
                            cantidad = 8000,
                            descripcion = "Gasohol 98",
                            API = 37.00m,
                            temp = 20.0m,
                            precioUnitario = 32.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 7680.00m,
                            Tratamiento = 10,
                            subTotal = 256000.00m,
                            total = 295000.00m
                        },
                        new
                        {
                            codigo = "4002",
                            serie = "SERIE008",
                            Tieneserie = true,
                            cantidad = 6000,
                            descripcion = "Diesel B5 S50",
                            API = 33.00m,
                            temp = 20.0m,
                            precioUnitario = 28.50m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 10260.00m,
                            Tratamiento = 10,
                            subTotal = 171000.00m,
                            total = 201260.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-223344",
                    FechaEmisionReferencia = "2024-10-30",
                    PlacaTransportista = "JKL-987",
                    LicenciaTransportista = "L-45678912",
                    MarcaTransportista = "VOLVO"
                },
                // Comprobante con errores adicionales
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F003",
                    NumCompra = "0001234569",
                    DocumentoProveedor = "205545457432055454574320554545743", // Error: demasiado largo
                    TipoDocumento = 2,
                    RazonSocial = "PRIMAX S.A.",
                    Sucursal = "Av. La Marina 456, San Miguel, Lima",
                    FechaEmision = "2024-10-24",
                    FechaVencimiento = "2024-11-11",
                    Moneda = "N",
                    Condicion = "R",
                    Observacion = "Compra de combustibles",
                    Scop = "123456789012", // Error: debe tener exactamente 10 caracteres
                    TotalGravadas = 180000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 32400.00m,
                    TotalPagar = 212400.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "3001",
                            serie = "SERIE005",
                            Tieneserie = true,
                            cantidad = 6000,
                            descripcion = "Gasohol 90",
                            API = 34.00m,
                            temp = 20.0m,
                            precioUnitario = 30.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 5400.00m,
                            Tratamiento = 10,
                            subTotal = 180000.00m,
                            total = 212400.00m
                        },
                        new
                        {
                            codigo = "3002",
                            serie = "SERIE006",
                            Tieneserie = true,
                            cantidad = 5000,
                            descripcion = "Diesel B5 S50",
                            API = 32.00m,
                            temp = 20.0m,
                            precioUnitario = 27.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 4860.00m,
                            Tratamiento = 10,
                            subTotal = 135000.00m,
                            total = 158220.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-123458",
                    FechaEmisionReferencia = "2024-10-22",
                    PlacaTransportista = "GHI-789",
                    LicenciaTransportista = "L-11223344",
                    MarcaTransportista = "MERCEDES"
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