﻿using DocumentManagementSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DocumentManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortDescriptionController : ControllerBase
    {
        private readonly ILogger<ShortDescriptionController> _logger;

        public ShortDescriptionController(ILogger<ShortDescriptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ShortDescriptionDocumentation> Get()
        {
            List<ShortDescriptionDocumentation> documents = new()
            {
                 new ShortDescriptionDocumentation()
                {
                    Id = Guid.NewGuid(),
                    Code = "PS",
                    Name = "PetStore",
                    Description = "Тестовый сваггер файл, для сравнения с оригиналом"
                },
                new ShortDescriptionDocumentation()
                {
                    Id = Guid.NewGuid(),
                    Code = "ECP",
                    Name = "Электронный клинический фармаколог",
                    Description = "«Электронный Клинический Фармаколог» – ассистент врача, помогающий минимизировать риск врачебных ошибок и подобрать персонализированную фармакотерапию пациенту. " +
                    "ЭКФ способствует снижению рисков врачебных ошибок и осложнений в клинической практике, а также сопровождает врача в условиях повышенной ответственности и нагрузки. ​" +
                    "При использовании ЭКФ  уменьшается количество побочных эффектов от применения лекарственных средств, сокращается время приема пациента, повышается качество оказания медицинской помощи, " +
                    "снижаются затраты медицинской организации на закупку медикаментов за счет более рациональных назначений врача."
                },
            };

            return documents;
        }
    }
}
