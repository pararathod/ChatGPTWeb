
using ChatGPTAPI.Models;
using ChatGPTAPI.Controllers;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatGPTAPI.Data;
using Microsoft.Extensions.Logging;
using ChatGPTAPI.Repository.Interface;
using Microsoft.Identity.Client;

namespace ChatGPTXUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void UserController_GetAll_ReturnokResult()
        {
            // AAA

            // Arrance
            var eventServicemoq = new Mock<IChatGPTRepository>();
            eventServicemoq.Setup(x => x.UserRepo.GetAllEvent()).ReturnsAsync(ChatGptTest.GetGptList());
            UserController eventCtr = new UserController(eventServicemoq.Object);

            //Act
              var result = await eventCtr.GetAll();
            

            //Assert.Notnull(result)    
            
            Assert.Empty(new List<ChatGpt>());
            
             
        }

        [Fact]
        public async void UserController_GetbyId_ReturnokResult()
        {
            // Get by ID
            int id = 1;
            // Arrance
            var eventServicemoq = new Mock<IChatGPTRepository>();
            eventServicemoq.Setup(x => x.UserRepo.GetById(id)).ReturnsAsync(new List<ChatGpt>());
            UserController eventCtr = new UserController(eventServicemoq.Object);

            //Act
            var result = await eventCtr.Get(id);

            //Assert    
            Assert.Empty(new List<ChatGpt>());

        }

        [Fact]
        public async void UserController_Save_ReturnokResult()
        {
            // Save

            ChatGpt chatGpt = new ChatGpt();
            // Arrance
            var eventServicemoq = new Mock<IChatGPTRepository>();
            eventServicemoq.Setup(x => x.UserRepo.Save(chatGpt));
            UserController eventCtr = new UserController(eventServicemoq.Object);

            //Act
            var result = await eventCtr.Save(chatGpt);

            //Assert    
            Assert.Empty(new List<ChatGpt>());

        }

        [Fact]
        public async void UserControllerDeleteReturnokResult()
        {
            // Delete

            int id = 1;
            // Arrance
            var eventServicemoq = new Mock<IChatGPTRepository>();
            eventServicemoq.Setup(x => x.UserRepo.Delete(id));
            UserController eventCtr = new UserController(eventServicemoq.Object);

            //Act
            var result = await eventCtr.Get(id);

            //Assert    
            Assert.Empty(new List<ChatGpt>());

        }


        [Fact]
        public async void UserController_Update_ReturnokResult()
        {
            // Put

            ChatGpt chatGpt = new ChatGpt();

            // Arrance
            var eventServicemoq = new Mock<IChatGPTRepository>();
            eventServicemoq.Setup(x => x.UserRepo.Put(chatGpt));
            UserController eventCtr = new UserController(eventServicemoq.Object);

            //Act
            var result = await eventCtr.Put(chatGpt);

            //Assert    
            Assert.Empty(new List<ChatGpt>());

        }


    }



}