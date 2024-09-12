/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                          Component : Web Api                               *
*  Assembly : Empiria.Payments.WebApi.dll                  Pattern   : Web api Controller                    *
*  Type     : PayableController                            License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update payable objects and their catalogues.                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Payments.Payables.UseCases;
using Empiria.Payments.Payables.Adapters;

namespace Empiria.Payments.Payables.WebApi {

  /// <summary>Web API used to retrive and update payable objects and their catalogues.</summary>
  public class PayableController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/payments-management/payables/payable-types")]
    public CollectionModel GetPaymentMethods() {

      using (var usecases = PayableUseCases.UseCaseInteractor()) {
        FixedList<NamedEntityDto> payableTypes = usecases.GetPayableTypes();

        return new CollectionModel(Request, payableTypes);
      }
    }

    #endregion Query web apis

    #region Command web apis

    [HttpPost]
    [Route("v2/payments-management/payables")]
    public SingleObjectModel CreatePayable([FromBody] PayableFields fields) {

      base.RequireBody(fields);

      using (var usecases = PayableUseCases.UseCaseInteractor()) {
        PayableDto payable = usecases.CreatePayable(fields);

        return new SingleObjectModel(base.Request, payable);
      }
    }


    #endregion Command web apis

  }  // class PayableController

}  // namespace Empiria.Payments.Payables.WebApi
