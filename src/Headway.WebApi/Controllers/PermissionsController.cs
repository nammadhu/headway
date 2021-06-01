﻿using Headway.Core.Interface;
using Headway.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Headway.WebApi.Controllers
{
    [ApiController]
    [EnableCors("local")]
    [Route("[controller]")]
    [Authorize(Roles = "headwayuser")]
    public class PermissionsController : ApiControllerBase<PermissionsController>
    {
        private readonly IAuthorisationRepository authorisationRepository;

        public PermissionsController(
            IAuthorisationRepository authorisationRepository,
            ILogger<PermissionsController> logger)
            : base(logger)
        {
            this.authorisationRepository = authorisationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var claim = GetUserClaim();

            var authorised = await authorisationRepository
                .IsAuthorisedAsync(claim, "Admin").ConfigureAwait(false);

            if (!authorised)
            {
                return Unauthorized();
            }

            var permissions = await authorisationRepository
                .GetPermissionsAsync().ConfigureAwait(false);

            return Ok(permissions);
        }

        [HttpGet("{permissionId}")]
        public async Task<IActionResult> Get(int permissionId)
        {
            var claim = GetUserClaim();

            var authorised = await authorisationRepository
                .IsAuthorisedAsync(claim, "Admin").ConfigureAwait(false);

            if (!authorised)
            {
                return Unauthorized();
            }

            var permissions = await authorisationRepository
                .GetPermissionAsync(permissionId).ConfigureAwait(false);

            return Ok(permissions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permission permission)
        {
            var claim = GetUserClaim();

            var authorised = await authorisationRepository
                .IsAuthorisedAsync(claim, "Admin").ConfigureAwait(false);

            if (!authorised)
            {
                return Unauthorized();
            }

            var savedPermission = await authorisationRepository
                .AddPermissionAsync(permission).ConfigureAwait(false);

            return Ok(savedPermission);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Permission permission)
        {
            var claim = GetUserClaim();

            var authorised = await authorisationRepository
                .IsAuthorisedAsync(claim, "Admin").ConfigureAwait(false);

            if (!authorised)
            {
                return Unauthorized();
            }

            var savedPermission = await authorisationRepository
                .UpdatePermissionAsync(permission).ConfigureAwait(false);

            return Ok(savedPermission);
        }

        [HttpDelete("{permissionId}")]
        public async Task<IActionResult> Delete(int permissionId)
        {
            var claim = GetUserClaim();

            var authorised = await authorisationRepository
                .IsAuthorisedAsync(claim, "Admin").ConfigureAwait(false);

            if (!authorised)
            {
                return Unauthorized();
            }

            var result = await authorisationRepository
                .DeletePermissionAsync(permissionId).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
