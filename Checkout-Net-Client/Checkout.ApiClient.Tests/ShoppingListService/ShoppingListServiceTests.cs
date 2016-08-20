using System.Linq;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Tests.Utils;

namespace Tests
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListTests : BaseServiceTests
    {
        [Test]
        public void AddItem()
        {
            var itemModel = TestHelper.GetShoppingListBaseItemModel();
            var response = CheckoutClient.ShoppingListService.AddItem(itemModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(itemModel.Name);
            response.Model.Quantity.Should().Be(itemModel.Quantity);
        }

        [Test]
        public void UpdateItem()
        {
            var itemModel = TestHelper.GetShoppingListBaseItemModel();
            var addItemResponse = CheckoutClient.ShoppingListService.AddItem(itemModel);
            
            var updateItemModel = TestHelper.GetShoppingListBaseItemModel(itemModel.Name);
            var response = CheckoutClient.ShoppingListService.UpdateItem(updateItemModel);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(updateItemModel.Name);
            response.Model.Quantity.Should().Be(updateItemModel.Quantity);
        }

        [Test]
        public void GetItem()
        {
            var itemModel = TestHelper.GetShoppingListBaseItemModel();
            var addItemResponse = CheckoutClient.ShoppingListService.AddItem(itemModel);

            var response = CheckoutClient.ShoppingListService.GetItem(addItemResponse.Model.Name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(itemModel.Name);
            response.Model.Quantity.Should().Be(itemModel.Quantity);
        }



        [Test]
        public void DeleteItem()
        {
            var itemModel = TestHelper.GetShoppingListBaseItemModel();
            var addItemResponse = CheckoutClient.ShoppingListService.AddItem(itemModel);

            var response = CheckoutClient.ShoppingListService.DeleteItem(addItemResponse.Model.Name);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Name.Should().Be(itemModel.Name);
            response.Model.Quantity.Should().Be(itemModel.Quantity);

            response = CheckoutClient.ShoppingListService.GetItem(addItemResponse.Model.Name);
            response.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        }



        [Test]
        public void GetItemList()
        {
            var itemModel = TestHelper.GetShoppingListBaseItemModel();
            var addItemResponse = CheckoutClient.ShoppingListService.AddItem(itemModel);

            var itemModel2 = TestHelper.GetShoppingListBaseItemModel();
            var addItemResponse2 = CheckoutClient.ShoppingListService.AddItem(itemModel2);

            var response = CheckoutClient.ShoppingListService.GetItemList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Count.Should().BeGreaterOrEqualTo(2);
        }
    }
}