using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManagerDATesting;
using DocumentsManager.Data.DA.Handler;
using DocumentsManagerExampleInstances;
using System.Linq;
using DocumentsManager.AuthenticationToken;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class UserBusinessLogicTest
    {

        public void SetUp()
        {
            ClearDataBase.ClearAll();
            UserContext context = new UserContext();
            User newuser = EntitiesExampleInstances.TestAdminUser();
            newuser.Username = "rareusername";
            newuser.Email = "rareemail";
            context.Add(newuser);
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.LogIn(newuser.Username, newuser.Password);
        }

        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public Document setUpAllSameStyle(FormatContext formatCtx, StyleClassContextHandler styleCtx)
        {
            SetUp();
            StyleClass style = new StyleClass
            {
                Name = "StyleTest",
                Id = Guid.NewGuid(),
                Attributes = new List<StyleAttribute>(),
                Based = null,
            };
            styleCtx.Add(style);
            Format format = new Format
            {
                Name = "formatTest",
                Id = Guid.NewGuid(),
                StyleClasses = new List<StyleClass>()
            };
            formatCtx.Add(format);
            Text footerText = CreateText(style);
            Text headerText = CreateText(style);
            Footer aFooter = new Footer
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                Text = footerText
            };
            Header aHeader = new Header
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                Text = headerText
            };
            List<Text> p1Texts = new List<Text>();
            p1Texts.Add(CreateText(style));
            Parragraph parragraph1 = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = null,
                StyleClass = style,
                Texts = p1Texts
            };
            List<Text> p2Texts = new List<Text>();
            p2Texts.Add(CreateText(style));
            p2Texts.Add(CreateText(style));
            Parragraph parragraph2 = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = null,
                StyleClass = style,
                Texts = p2Texts
            };
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph1);
            parragraphs.Add(parragraph2);
            Document aDocument = new Document
            {
                Id = Guid.NewGuid(),
                Footer = aFooter,
                Format = format,
                Header = aHeader,
                Parragraphs = parragraphs,
                StyleClass = style,
                Title = "Test Title"
            };
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "testUsername"
            };
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            adminLogic.AddAdmin(admin, Guid.NewGuid());
            logic.AddDocument(aDocument, admin);
            return aDocument;
        }

        public Text CreateText(StyleClass style)
        {
            Text testText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                WrittenText = "TESTTEXT"
            };
            return testText;
        }
        [TestMethod]
        public void AddDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            IEnumerable<Document> allDocuments = documentLogic.GetAllDocuments(Guid.NewGuid());
            Assert.IsTrue(allDocuments.Contains(aDocument));
            Assert.IsTrue(allDocuments.Count() == 1);
            TearDown();
        }
        [TestMethod]
        public void ModifyTitleDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            aDocument.Title = "new Title";
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            logic.ModifyDocumentProperties(aDocument, admin);
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).Title.Equals("new Title"));
            TearDown();
        }
        [TestMethod]
        public void ModifyParragraphsDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            Text modifiedText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = aDocument.StyleClass,
                WrittenText = "MODIFIED"
            };
            List<Text> texts = new List<Text>();
            texts.Add(modifiedText);
            Parragraph parragraph = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = aDocument,
                StyleClass = aDocument.StyleClass,
                Texts = texts
            };
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph);
            aDocument.Parragraphs = parragraphs;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyParragraphs(aDocument, admin);

            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).Parragraphs.Count == 1);
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).Parragraphs.ElementAt(0).Equals(parragraph));
            TearDown();
        }
        [TestMethod]
        public void ModifyParragraphsDocumentTestTwice()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            Text modifiedText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = aDocument.StyleClass,
                WrittenText = "MODIFIED"
            };
            List<Text> texts = new List<Text>();
            texts.Add(modifiedText);
            Parragraph parragraph = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = aDocument,
                StyleClass = aDocument.StyleClass,
                Texts = texts
            };
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph);
            aDocument.Parragraphs = parragraphs;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyParragraphs(aDocument, admin);
            aDocument.Parragraphs = new List<Parragraph>();
            logic.ModifyParragraphs(aDocument, admin);

            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).Parragraphs.Count == 0);
            TearDown();
        }
        [TestMethod]
        public void CreateNewSession()
        {
            SessionAccess sessionAccess = new SessionAccess();
            Guid newGuidUser = Guid.NewGuid();
            Guid newToken = sessionAccess.Add(newGuidUser);
            Assert.IsTrue(sessionAccess.SessionAlreadyOpen(newGuidUser));
            sessionAccess.Remove(newToken);
            TearDown();
        }
        [TestMethod]
        public void CheckNotCreatedSession()
        {
            SessionAccess sessionAccess = new SessionAccess();
            Guid newGuidUser = Guid.NewGuid();
            Assert.IsFalse(sessionAccess.SessionAlreadyOpen(newGuidUser));
            TearDown();
        }
        [TestMethod]
        public void GetUserByToken()
        {
            SessionAccess sessionAccess = new SessionAccess();
            Guid newGuidUser = Guid.NewGuid();
            Guid token = sessionAccess.Add(newGuidUser);
            Guid idUser = sessionAccess.GetIdByToken(token);
            Assert.IsTrue(newGuidUser == idUser);
            sessionAccess.Remove(token);
            TearDown();
        }
        [ExpectedException(typeof(UserAlreadyLogged))]
        [TestMethod]
        public void CreateConnectionAlreadyLogged()
        {
            SetUp();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            adminLogic.AddAdmin(newAdmin, Guid.NewGuid());
            Guid token = logic.LogIn(newAdmin.Username, newAdmin.Password);
            Guid anotherToken = logic.LogIn(newAdmin.Username, newAdmin.Password);
            TearDown();
        }
        [TestMethod]
        public void CheckGetUserByTokenOk()
        {
            SetUp();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            adminLogic.AddAdmin(newAdmin, Guid.NewGuid());
            Guid token = logic.LogIn(newAdmin.Username, newAdmin.Password);
            Assert.AreEqual(newAdmin, logic.GetUserByToken(token));
            TearDown();
        }
        [TestMethod]
        public void CreateConnectionAfterLogOut()
        {
            SetUp();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            adminLogic.AddAdmin(newAdmin, Guid.NewGuid());
            Guid token = logic.LogIn(newAdmin.Username, newAdmin.Password);
            logic.LogOut(token);
            Guid anotherToken = logic.LogIn(newAdmin.Username, newAdmin.Password);
            Assert.AreEqual(newAdmin, logic.GetUserByToken(anotherToken));
            TearDown();
        }
        [ExpectedException(typeof(InvalidCredentialException))]
        [TestMethod]
        public void InvalidCredential()
        {
            SetUp();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            AdminUser newAdmin = EntitiesExampleInstances.TestAdminUser();
            adminLogic.AddAdmin(newAdmin, Guid.NewGuid());
            Guid token = logic.LogIn(newAdmin.Username, "notThePassword");
            TearDown();
        }
        [TestMethod]
        public void IsTokenActiveFalse()
        {
            TearDown();
            UserBusinessLogic logic = new UserBusinessLogic();
            Guid token = Guid.NewGuid();
            Assert.IsFalse(logic.IsTokenActive(token));
            TearDown();
        }
        [TestMethod]
        public void IsTokenActiveOk()
        {
            ClearDataBase.ClearAll();
            UserContext context = new UserContext();
            User newuser = EntitiesExampleInstances.TestAdminUser();
            newuser.Username = "rareusername";
            newuser.Email = "rareemail";
            context.Add(newuser);
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            Guid token = adminBL.LogIn(newuser.Username, newuser.Password);
            Assert.IsTrue(logic.IsTokenActive(token));
            TearDown();
        }
        [TestMethod]
        public void ReleaseAllSessionsTest()
        {
            ClearDataBase.ClearAll();
            UserContext context = new UserContext();
            User newuser = EntitiesExampleInstances.TestAdminUser();
            newuser.Username = "rareusername";
            newuser.Email = "rareemail";
            context.Add(newuser);
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            Guid token = adminBL.LogIn(newuser.Username, newuser.Password);
            logic.ReleaseAllSessions();
            Assert.IsFalse(logic.IsTokenActive(token));
            TearDown();
        }
        [TestMethod]
        public void ModifyStyleClassDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);

            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            StyleClass style = new StyleClass
            {
                Id = Guid.NewGuid(),
                Name = "ModifiedStyle",
                Attributes = new List<StyleAttribute>(),
                Based = null
            };
            styleCtx.Add(style);
            aDocument.StyleClass = style;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyDocumentProperties(aDocument, admin);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).StyleClass.Name.Equals("ModifiedStyle"));
            TearDown();
        }
        [TestMethod]
        public void ModifyFormatDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);

            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            Format format = new Format
            {
                Id = Guid.NewGuid(),
                Name = "ModifiedFormat",
                StyleClasses = new List<StyleClass>()
            };
            formatCtx.Add(format);
            aDocument.Format = format;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyDocumentProperties(aDocument, admin);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id, Guid.NewGuid()).Format.Name.Equals("ModifiedFormat"));
            TearDown();
        }
        [TestMethod]
        public void ModifyHeaderDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            StyleClass style = new StyleClass
            {
                Id = Guid.NewGuid(),
                Name = "ModifiedStyle",
                Attributes = new List<StyleAttribute>(),
                Based = null
            };
            styleCtx.Add(style);
            Text newHeaderText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                WrittenText = "ModifiedHeader"
            };
            aDocument.Header.StyleClass = aDocument.StyleClass;
            aDocument.Header.Text = newHeaderText;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyDocumentHeader(aDocument, admin);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            HeaderBusinessLogic hLogic = new HeaderBusinessLogic();
            Assert.IsTrue(hLogic.GetById(aDocument.Header.Id).Text.HasSameText(newHeaderText));
            Assert.IsTrue(hLogic.GetById(aDocument.Header.Id).Text.StyleClass.Equals(newHeaderText.StyleClass));

            TearDown();
        }
        [TestMethod]
        public void ModifyFooterDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            StyleClass style = new StyleClass
            {
                Id = Guid.NewGuid(),
                Name = "ModifiedStyle",
                Attributes = new List<StyleAttribute>(),
                Based = null
            };
            styleCtx.Add(style);
            Text newFooterText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                WrittenText = "ModifiedFooter"
            };
            aDocument.Footer.StyleClass = style;
            aDocument.Footer.Text = newFooterText;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyDocumentFooter(aDocument, admin);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            FooterBusinessLogic fLogic = new FooterBusinessLogic();
            Assert.IsTrue(fLogic.GetById(aDocument.Footer.Id).Text.HasSameText(newFooterText));
            Assert.IsTrue(fLogic.GetById(aDocument.Footer.Id).Text.StyleClass.Equals(newFooterText.StyleClass));
            Assert.IsTrue(fLogic.GetById(aDocument.Footer.Id).StyleClass.Equals(style));
            TearDown();
        }
        [TestMethod]
        public void AreFriendsTestTrue()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Friendship friendship = new Friendship
            {
                Id = Guid.NewGuid(),
                State = FriendshipState.Friend,
                Request = userRequester,
                Requested = userRequested
            };
            fContext.Add(friendship);
            Assert.IsTrue(uBL.AreFriends(userRequester, userRequested));
            TearDown();
        }
        [TestMethod]
        public void AreFriendsTestTrueReverse()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Friendship friendship = new Friendship
            {
                Id = Guid.NewGuid(),
                State = FriendshipState.Friend,
                Request = userRequester,
                Requested = userRequested
            };
            fContext.Add(friendship);
            Assert.IsTrue(uBL.AreFriends(userRequested, userRequester));
            TearDown();
        }
        [TestMethod]
        public void AreFriendsTestFalse()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            AdminUser AnotherUser = EntitiesExampleInstances.TestAdminUser();
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            aBL.AddAdmin(AnotherUser, Guid.NewGuid());
            Friendship friendship = new Friendship
            {
                Id = Guid.NewGuid(),
                State = FriendshipState.Friend,
                Request = userRequester,
                Requested = userRequested
            };
            fContext.Add(friendship);
            Assert.IsFalse(uBL.AreFriends(userRequester, AnotherUser));
            TearDown();
        }
        [TestMethod]
        public void AddFriendRequest()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Guid token = uBL.LogIn(userRequester.Username, userRequester.Password);
            uBL.AddFriend(userRequested.Id, token);
            List<Friendship> relations = fContext.GetAllFriendships();
            Assert.AreEqual(1, relations.Count);
            uBL.LogOut(token);
            TearDown();
        }
        [TestMethod]
        public void AddFriendRequestNotFriendsYet()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Guid token = uBL.LogIn(userRequester.Username, userRequester.Password);
            uBL.AddFriend(userRequested.Id, token);
            List<Friendship> relations = fContext.GetAllFriendships();
            Assert.AreEqual(1, relations.Count);
            Assert.IsFalse(uBL.AreFriends(userRequester, userRequested));
            uBL.LogOut(token);
            TearDown();
        }
        [ExpectedException(typeof(AlreadySentRequestException))]
        [TestMethod]
        public void AddFriendAlreadySent()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Guid token = uBL.LogIn(userRequester.Username, userRequester.Password);
            uBL.AddFriend(userRequested.Id, token);
            uBL.AddFriend(userRequested.Id, token);
            uBL.LogOut(token);
            TearDown();
        }
        [TestMethod]
        public void AddFriendBothSides()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Guid token1 = uBL.LogIn(userRequester.Username, userRequester.Password);
            uBL.AddFriend(userRequested.Id, token1);
            uBL.LogOut(token1);
            Guid token2 = uBL.LogIn(userRequested.Username, userRequested.Password);
            uBL.AddFriend(userRequester.Id, token2);
            List<Friendship> relations = fContext.GetAllFriendships();
            Assert.AreEqual(1, relations.Count);
            Assert.IsTrue(uBL.AreFriends(userRequester, userRequested));
            uBL.LogOut(token2);
            TearDown();
        }
        [ExpectedException(typeof(AlreadyFriendsException))]
        [TestMethod]
        public void AddFriendAlreadyFriends()
        {
            SetUp();
            FriendshipContext fContext = new FriendshipContext();
            UserBusinessLogic uBL = new UserBusinessLogic();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            AdminUser userRequester = EntitiesExampleInstances.TestAdminUser();
            userRequester.Username = "requester";
            userRequester.Email = "requester@requester";
            AdminUser userRequested = EntitiesExampleInstances.TestAdminUser();
            userRequested.Username = "requested";
            userRequested.Email = "requested@requested";
            aBL.AddAdmin(userRequester, Guid.NewGuid());
            aBL.AddAdmin(userRequested, Guid.NewGuid());
            Guid token1 = uBL.LogIn(userRequester.Username, userRequester.Password);
            uBL.AddFriend(userRequested.Id, token1);
            uBL.LogOut(token1);
            Guid token2 = uBL.LogIn(userRequested.Username, userRequested.Password);
            uBL.AddFriend(userRequester.Id, token2);
            uBL.AddFriend(userRequester.Id, token2);
            uBL.LogOut(token2);
            TearDown();
        }
    }
}