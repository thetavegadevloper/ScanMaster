var Names = []
var Codes = []
var Types = []
var BarCodes = []
//fetch categories from database
function LoadModelName(element) {
    if (Names.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/ModelMaster/GetModelName',
            success: function (data) {
                Names = data;
                //render catagory
                renderModelName(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderModelName(element);
    }
}
function renderModelName(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Names, function (i, val) {
        $ele.append($('<option/>').val(val.ID).text(val.ModelName));
    })
}



function LoadType(element) {
    if (Types.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/ModelMaster/GetCategoryList',
            success: function (data) {
                Types = data;
                //render catagory
                renderLoadType(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderLoadType(element);
    }
}

function renderLoadType(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Types, function (i, val) {
        $ele.append($('<option/>').val(val.ID).text(val.TypeName));
    })
}





function LoadModelCodes(element) {
    if (Codes.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/ModelMaster/GetModelCode',
            success: function (data) {
                Codes = data;
                //render catagory
                renderModelCodes(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderModelCodes(element);
    }
}

function renderModelCodes(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Codes, function (i, val) {
        $ele.append($('<option/>').val(val.ID).text(val.ModelCode));
    })
}

function LoadBarCodes(element) {
    if (BarCodes.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/ModelMaster/GetBarCode',
            success: function (data) {
                BarCodes = data;
                //render catagory
                renderBarCodes(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderBarCodes(element);
    }
}

function renderBarCodes(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(BarCodes, function (i, val) {
        $ele.append($('<option/>').val(val.ID).text(val.Barcode));
    })
}

function LoadProduct(categoryDD) {
    $.ajax({
        type: "GET",
        url: "/ModelMaster/getProducts",
        data: { 'categoryID': $(categoryDD).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderProduct($(categoryDD).parents('.mycontainer').find('#bcode'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderProduct(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
   
    $.each(data, function (_i, val) {
        $ele.append($.text(val.Barcode));
    })
}

LoadBarCodes($('#Barcode1'));

LoadModelName($('#ModelName'));
LoadModelCodes($('#ModelCode'));

  

     
             

