/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                         Component : Web Api                               *
*  Assembly : Empiria.Payments.WebApi.dll                  Pattern   : Query web api controller              *
*  Type     : CataloguesController                         License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive payment orders catalogues.                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Payments.Orders.UseCases;

namespace Empiria.Payments.Orders.WebApi {

  /// <summary>Query web API used to retrive payment orders catalogues.</summary>
  public class CataloguesController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/payments-management/catalogues/payment-methods")]
    public CollectionModel GetPaymentMethods() {

      using (var usecases = CataloguesUseCases.UseCaseInteractor()) {
        FixedList<NamedEntityDto> paymentMethods = usecases.GetPaymentMethods();

        return new CollectionModel(Request, paymentMethods);
      }
    }


    [HttpGet]
    [Route("v2/payments-management/catalogues/payment-order-types")]
    public CollectionModel GetPaymentOrderTypes() {

      using (var usecases = CataloguesUseCases.UseCaseInteractor()) {
        FixedList<NamedEntityDto> paymentMethods = usecases.GetPaymentOrderTypes();

        return new CollectionModel(Request, paymentMethods);
      }
    }

    #endregion Query web apis

  }  // class CataloguesController

}  // namespace Empiria.Payments.WebApi.PaymentOrders
