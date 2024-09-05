/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Payments Management                        Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Data Transfer Object                    *
*  Type     : PaymentOrderDto, PaymentOrderDescriptor    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Data transfer objects used to return payment orders.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.DynamicData;
using Empiria.StateEnums;

namespace Empiria.Payments.Orders.Adapters {

  /// <summary>Output DTO used to return full payment orders.</summary>
  public class PaymentOrderDto {

    public string UID {
      get; internal set;
    }


    public string OrderNo {
      get; internal set;
    }


    public string PayTo {
      get; internal set;
    }


    public string PayToType {
      get; internal set;
    }


    public string BussinesObjectType {
      get; internal set;
    }


    public string BussinesObject {
      get; internal set;
    }


    public string RequestedBy {
      get; internal set;
    }


    public DateTime RequestedDate {
      get; internal set;
    }


    public string Notes {
      get; internal set;
    }


    public decimal Total {
      get; internal set;
    }


    public EntityStatus Status {
      get; internal set;
    }

  }  // class PaymentOrderDto

  public class SearchSalesOrderDto {



  } // class SearchSalesOrderDto

  /// <summary>Output DTO used to return minimal payment order's data for use in lists.</summary>
  public class PaymentOrderDescriptor {

    public PaymentOrdersQuery Query {
      get; internal set;
    }

    public FixedList<DataTableColumn> Columns {
      get; internal set;
    }

    public FixedList<PaymentOrderDescriptorDto> Entries {
      get; internal set;
    }



  }  // class PaymentOrderDescriptor


  /// <summary>Output DTO used to return minimal payment order's data for use in lists.</summary>
  public class PaymentOrderDescriptorDto {


    public string UID {
      get; internal set;
    }


    public string PaymentOrderNo {
      get; internal set;
    }


    public string PayTo {
      get; internal set;
    }


    public string Payable {
      get; internal set;
    }


    public string PaymentMethod {
      get; internal set;
    }


    public decimal Total {
      get; internal set;
    }


    public string Currency {
      get; internal set;
    }


    public DateTime RequestedDate {
      get; internal set;
    }


    public DateTime DueTime {
      get; internal set;
    }


    public string RequestedBy {
      get; internal set;
    }


    public EntityStatus Status {
      get; internal set;
    }

  } // class PaymentOrderDescriptorDto


}  // namespace Empiria.Payments.Orders.Adapters
