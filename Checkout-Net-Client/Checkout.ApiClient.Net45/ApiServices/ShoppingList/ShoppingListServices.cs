using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        public HttpResponse<Item> AddItem(BaseItem item)
        {
            var createAddItemUri = string.Format(ApiUrls.ShoppingListAddItem);
            return new ApiHttpClient().PostRequest<Item>(createAddItemUri,null, item);
        }

        public HttpResponse<Item> UpdateItem(BaseItem item)
        {
            var updateItemUri = string.Format(ApiUrls.ShoppingListUpdateItem, item);
            return new ApiHttpClient().PutRequest<Item>(updateItemUri,null, item);
        }

        public HttpResponse<Item> GetItem(string Name)
        {
            var getItemUri = string.Format(ApiUrls.ShoppingListGetItem, Name);
            return new ApiHttpClient().GetRequest<Item>(getItemUri,null);
        }
        public HttpResponse<Item> DeleteItem(string Name)
        {
            var deleteItemUri = string.Format(ApiUrls.ShoppingListDeleteItem, Name);
            return new ApiHttpClient().DeleteRequest<Item>(deleteItemUri,null);
        }
        public HttpResponse<ItemList> GetItemList()
        {
            var getShoppingListUri = string.Format(ApiUrls.ShoppingListGetAll);
            return new ApiHttpClient().GetRequest<ItemList>(getShoppingListUri, null);
        }

    }
}
