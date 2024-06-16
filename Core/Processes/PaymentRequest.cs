/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Supplier Payments Procesess                Component : Domain Layer                            *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Infomation Holder                       *
*  Type     : PaymentRequest                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a supplier payment related request.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Parties;

using Empiria.Workflow.Requests;
using Empiria.Workflow.Requests.Adapters;

namespace Empiria.Payments.Processes {

  /// <summary>Represents a supplier payment related request.</summary>
  public class PaymentRequest : Request {

    protected PaymentRequest(RequestType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }


    protected override void Update(RequestFieldsDto fields) {
      base.Update(fields);

      this.UniqueID = $"GP-{DateTime.Today.Year}-00001";
      this.ControlID = $"{DateTime.Today.Year}-00001";
      this.Requester = Person.Parse(ExecutionServer.CurrentUserId);
      this.RequesterName = Requester.Name;
      this.Description = $"{RequestType.DisplayName}";
    }

  }  // class PaymentRequest

}  // namespace Empiria.Payments.Processes
