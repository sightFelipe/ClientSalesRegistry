using Microsoft.AspNetCore.Mvc;
using ClientSalesRegistry.DTOs;
using ClientSalesRegistry.Services.customerService.impl;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly CustomerServiceImpl _customerService;

    public CustomerController(CustomerServiceImpl customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdCustomerDto = await _customerService.CreateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomerByDocument), new { document = createdCustomerDto.Document }, createdCustomerDto);
    }

    [HttpGet("{document}")]
    public async Task<IActionResult> GetCustomerByDocument(string document) 
    {
        var customer = await _customerService.GetCustomerByDocumentAsync(document);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpPut("{document}")] 
    public async Task<IActionResult> UpdateCustomer(string document, [FromBody] CustomerDto customerDto) 
    {
        var updatedCustomer = await _customerService.UpdateCustomerAsync(customerDto, document);
        if (updatedCustomer == null) return NotFound();
        return Ok(updatedCustomer);
    }

    [HttpDelete("{document}")]
    public async Task<IActionResult> DeleteCustomer(string document)
    {
        try
        {
            
            await _customerService.DeleteCustomerAsync(document);

            
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            
            return StatusCode(500, "Error al eliminar el cliente: " + ex.Message);
        }
    }
}