﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Domas.Web.Mvc.Examples.Models.ProductViewModel>" %>

<div class="product-view k-widget">
    <div class="edit-buttons">
        <a class="k-button k-button-icontext k-update-button" href="\\#"><span class="k-icon k-update"></span></a>
        <a class="k-button k-button-icontext k-cancel-button" href="\\#"><span class="k-icon k-cancel"></span></a>
    </div>
    <dl>
        <dt>Product Name</dt>
        <dd>
            <%:Html.EditorFor(p=>p.ProductName)%>
            <span data-for="ProductName" class="k-invalid-msg"></span>
        </dd>
        <dt>Unit Price</dt>
        <dd>
            <%:Html.EditorFor(p=>p.UnitPrice)%>
            <span data-for="UnitPrice" class="k-invalid-msg"></span>
        </dd>
        <dt>Units In Stock</dt>
        <dd>
            <%:Html.EditorFor(p=>p.UnitsInStock)%>
            <span data-for="UnitsInStock" class="k-invalid-msg"></span>
        </dd>
        <dt>Discontinued</dt>
        <dd><%:Html.EditorFor(p=>p.Discontinued)%></dd>
    </dl>
</div>