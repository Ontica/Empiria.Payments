/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Contracts Management                         Component : Web Api                               *
*  Assembly : Empiria.Payments.WebApi.dll                  Pattern   : Web api Controller                    *
*  Type     : PaymentOrderController                       License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update payments.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Payments.Contracts.Adapters;
using Empiria.Payments.Contracts.UseCases;
using Empiria.Payments.Orders.UseCases;
using Empiria.Payments.Orders.Adapters;

namespace Empiria.Payments.WebApi.PaymentOrders
{

    /// <summary>Web API used to retrive and update contracts</summary>
    public class PaymentOrderController : WebApiController
    {

    #region Query web apis


        [HttpGet]
        [Route("v2/payments/currencies")]
        public CollectionModel GetCurrencies() {

          using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
            FixedList<NamedEntityDto> currencies = usecases.GetCurrencies();

            return new CollectionModel(Request, currencies);
          }
        }


        [HttpGet]
        [Route("v2/payments/payment-methods")]
        public CollectionModel GetPaymentMethods() {

            using (var usecases = PaymentOrderUseCases.UseCaseInteractor())
            {
                FixedList<NamedEntityDto> paymentMethods = usecases.GetPaymentMethods();

                return new CollectionModel(Request, paymentMethods);
            }
        }


        [HttpGet]
        [Route("v2/payments/payment-order-types")]
        public CollectionModel GetPaymentOrderTypes() {

          using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
            FixedList<NamedEntityDto> paymentMethods = usecases.GetPaymentOrderTypes();

            return new CollectionModel(Request, paymentMethods);
          }
        }


    #endregion Query web apis

    #region Command web apis


    [HttpPost]
    [Route("v2/payments/payment-order")]
    public SingleObjectModel AddPaymentOrder([FromBody] PaymentOrderFields fields) {

      base.RequireBody(fields);

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {
        var paymentOrderDto = usecases.AddPaymentOrder(fields);

        return new SingleObjectModel(base.Request, paymentOrderDto);
      }
    }


    [HttpPut]
    [Route("v2/payments/payment-order/{paymentOrderUID:guid}")]
    public SingleObjectModel UpdatePaymentOrder([FromUri] string paymentOrderUID, [FromBody] PaymentOrderFields fields) {

      base.RequireResource(paymentOrderUID, "paymentOrderUID");
      base.RequireBody(fields);

      using (var usecases = PaymentOrderUseCases.UseCaseInteractor()) {

        var paymentOrderDto = usecases.UpdatePaymentOrder(paymentOrderUID, fields);

        return new SingleObjectModel(this.Request, paymentOrderDto);
      }

    }


    #endregion Command web apis

  }  // class PaymentOrderController

}  // namespace Empiria.Payments.WebApi.PaymentOrders
