using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using SysRH.Domain.Entities;
using SysRH.Infra.Context;
using SysRH.Services.DTO;
using SysRH.Services.Interfaces;
using System.IO;

namespace SysRH.API.Controllers;

[ApiController]
[Route("api/v1")]
public class EmployeeController : ControllerBase
{
    private readonly SysRHContext _context;

    private readonly IEmployeeServiceInterface _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeServiceInterface employeeService, IMapper mapper, SysRHContext context)
    {
        _context = context;
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("/Post")]
    public async Task<IActionResult> Post(EmployeeDTO employee)
    {
        var emp = await _employeeService.Create(employee);
        return Ok();
    }

    [HttpGet]
    [Route("/Get")]
    public async Task<IActionResult> Get()
    {
        return Ok(_mapper.Map<List<Employee>>(await _employeeService.Get()));
    }

    [HttpGet]
    [Route("/Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok((await _employeeService.Get(id)));
    }

    [HttpGet]
    [Route("/GetCPF/{CPF}")]
    public async Task<IActionResult> GetCPF(int CPF)
    {
        return Ok((await _employeeService.GetByCpf(CPF)));
    }

    [HttpDelete]
    [Route("/Delete")]
    public async Task<IActionResult> Remove(int id)
    {
        var employeeRemove = await _employeeService.Get(id);
        await _employeeService.Remove(employeeRemove.Id);
        return Ok();
    }

    [HttpPut]
    [Route("/update/{id}")]
    public async Task<IActionResult> Update(int id, EmployeeDTO employee)
    {
        var userExists = await _employeeService.Get(id);
        if (userExists != null)
        {
            await _employeeService.Update(employee);
            return Ok(employee);
        }

        throw new Exception();
    }


    [HttpGet]
    [Route("/Download/History/{id}")]
    public async Task<IActionResult> DownloadHistory(long id)
    {
        var file = await _employeeService.DownloadHistory(id);
        var databytes = System.IO.File.ReadAllBytes(file);
        return Ok(System.IO.File.Open(file, FileMode.Open));
    }    
    [HttpGet]
    [Route("/Download/Trainings/{id}")]
    public async Task<IActionResult> DownloadTrainings(long id)
    {
        var file = await _employeeService.DownloadTrainings(id);
        var databytes = System.IO.File.ReadAllBytes(file);
        return Ok(System.IO.File.Open(file, FileMode.Open));
    }  
    [HttpGet]
    [Route("/Get/Name/{pesquisa}")]
    public async Task<IActionResult> SearchByName(string pesquisa)
    {
        var emp = await _employeeService.SearchByName(pesquisa);
        return Ok(emp);
    }
}