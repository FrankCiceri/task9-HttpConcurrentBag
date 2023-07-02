using NUnit.Framework.Interfaces;
using System;
using System.Net;
using Task9.Models.Requests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Task9.Steps.UserServiceSteps
{
    [Binding]
    public sealed class UserAssertSteps
    {
        private readonly DataContext _context;

        public UserAssertSteps(DataContext context)
        {

            _context = context;

        }
       


        [Then(@"Status code from register user response is '([^']*)'")]
        public void ThenStatusCodeFromRegisterUserResponseIs(string expected)
        {
            var expectedStatus = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);

            var actualStatus = _context.GetResponse.StatusCode;

            Assert.That(expectedStatus, Is.EqualTo(actualStatus));
        }


        [Then(@"Status code from request response is '([^']*)'")]
        public void ThenStatusCodeFromRequestResponseIs(string expected)
        {
            var expectedStatus = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);

            var actualStatus = _context.GetResponse.StatusCode;

            Assert.That(expectedStatus, Is.EqualTo(actualStatus));
        }


        [Then(@"User status is '([^']*)' and Delete StatusCode is '([^']*)'")]
        public void ThenUserStatusIsAndStatusCodeIsOK(string Expectedstatus, string statusCodeString)
        {
            var status = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), statusCodeString);

            Assert.Multiple(() => {
                Assert.That(_context.GetUserStatus, Is.EqualTo(Expectedstatus));
                Assert.That(_context.DeleteUserStatusCode, Is.EqualTo(status));
            });
        }

        [Then(@"Second Id is greater than first Id")]
        public void ThenSecondIdIsGreaterThanFirstId()
        {

            Assert.That(_context.Id2, Is.GreaterThan(_context.Id1));
        }
                

        [Then(@"Status code from delete is '([^']*)'")]
        public void ThenStatusCodeFromDeleteIs(string expected)
        {
            var status = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);
            Assert.That(_context.DeleteUserStatusCode, Is.EqualTo(status));
        }


        [Then(@"Status code from set is '([^']*)'")]
        public void ThenStatusCodeFromSetIs(string expected)
        {
            var status = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);
            Assert.That(_context.SetStatusResponseCode, Is.EqualTo(status));
        }

        [Then(@"Body from get status is '([^']*)'")]
        public void ThenBodyFromGetStatusIs(string p0)
        {
            Assert.That(_context.GetUserStatus, Is.EqualTo("Sequence contains no elements"));
        }




    }
}