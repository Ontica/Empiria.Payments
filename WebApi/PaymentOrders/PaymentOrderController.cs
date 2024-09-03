/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                          Component : Web Api                               *
*  Assembly : Empiria.Payments.WebApi.dll                  Pattern   : Web api Controller                    *
*  Type     : PaymentOrderController                       License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update payment orders.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Payments.Orders.UseCases;
using Empiria.Payments.Orders.Adapters;

namespace Empiria.Payments.Orders.WebApi {

  /// <summary>Web API used to retrive and update payment orders.</summary>
  public class PaymentOrderController : WebApiController {

    #region Query web apis
     
    [HttpGet]
    [Route("v2/payments-management/payment-orders/{paymentOrderUID:guid}")]
    public SingleObjectModel GetPaymentOrder([FromUri] string paymentOrderUID) {

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
        PaymentOrderDto paymentOrder = usecases.GetPaymentOrder(paymentOrderUID);

        return new SingleObjectModel(base.Request, paymentOrder);
      }
    }


    [HttpPost]
    [Route("v2/payments-management/payment-orders/search")]
    public SingleObjectModel GetPaymentOrders([FromBody] PaymentOrdersQuery query) {

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
        PaymentOrderDescriptor paymentOrders = usecases.GetPaymentOrders(query);

        return new SingleObjectModel(base.Request, paymentOrders);
      }
    }

    #endregion Query web apis

    #region Command web apis

    [HttpPost]
    [Route("v2/payments-management/payment-orders")]
    public SingleObjectModel CreatePaymentOrder([FromBody] PaymentOrderFields fields) {

      base.RequireBody(fields);

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
        var paymentOrderDto = usecases.CreatePaymentOrder(fields);

        return new SingleObjectModel(base.Request, paymentOrderDto);
      }
    }


    [HttpDelete]
    [Route("v2/payments-management/payment-orders/{paymentOrderUID:guid}/items/{itemUID}")]
    public NoDataModel DeletePaymentOrder([FromUri] string paymentOrderUID) {

      base.RequireResource(paymentOrderUID, nameof(paymentOrderUID));

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {

        usecases.DeletePaymentOrder(paymentOrderUID);

        return new NoDataModel(this.Request);
      }
    }


    [HttpPut]
    [Route("v2/payments-management/payment-orders/{paymentOrderUID:guid}")]
    public SingleObjectModel UpdatePaymentOrder([FromUri] string paymentOrderUID,
                                                [FromBody] PaymentOrderFields fields) {

      base.RequireResource(paymentOrderUID, nameof(paymentOrderUID));
      base.RequireBody(fields);

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {

        var paymentOrderDto = usecases.UpdatePaymentOrder(paymentOrderUID, fields);

        return new SingleObjectModel(this.Request, paymentOrderDto);
      }
    }

    #endregion Command web apis

  }  // class PaymentOrderController

}  // namespace Empiria.Payments.WebApi.PaymentOrders
