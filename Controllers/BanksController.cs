﻿using BankClientApi.Models.RequestModels;
using BankClientApi.Services.BankService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        //injecting the bank service
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            this._bankService = bankService;
        }
        /// <summary>
        /// Gets the list of banks from an external API
        /// </summary>
        /// <returns>A list of Bank objects</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBankData()
        {
            try
            {
                var banks = await _bankService.GetBankDataAsync();
                return banks;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Gets the available branches for a given bank id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of BankBranch objects</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BankBranch>>> GetBranchesForId(int id)
        {
            try
            {
                var branchesForBankId = await _bankService.GetBankBranchDataForBankAsync(id);
                return branchesForBankId;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Gets all bank branches for all banks
        /// </summary>
        /// <returns>A list of BankBranch objects</returns>
        [HttpGet]
        [Route("/getallbranches")]
        public async Task<ActionResult<IEnumerable<BankBranch>>> GetAllBranches()
        {
            try
            {
                var branchesForBankId = await _bankService.GetAllBankBranchDataAsync();
                return branchesForBankId;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
