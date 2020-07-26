<%@ Page Title="PayU BOLT" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="payu_bolt._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>

    <%--    <script type="text/javascript" id="bolt" src="https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="http://boltiswatching.com/wp-content/uploads/2015/09/Bolt-Logo-e14421724859591.png"></script>
    --%>
    <!-- BOLT Production/Live //-->
    <script type="text/javascript" id="bolt" src="https://checkout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="http://boltiswatching.com/wp-content/uploads/2015/09/Bolt-Logo-e14421724859591.png"></script>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
       
                <div class="row" style="border: 1px solid #ebebeb; text-align: center">
                    <div class="col-md-12">
                        <br />
                        <br />
                        <h5>DO FOR THE NATION…..DONATION</h5>
                        <br />
                        <br />
                        <h1 class="text-center">I STAND FOR THE NATION is a trust having a strong objective towards the support of the Brave Hearts</h1>
                        <br />
                        <br />
                        <p>
                            Each penny collected on behalf of this trust will be supported towards to the jawan welfare. So, folks ‘Do for the nation’ which we call it as Donation
                        </p>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-6">

                                <input type="text" id="amount" class="form-control" name="amount" placeholder="Amount" value="" />

                            </div>
                            <div class="col-md-6">

                                <input type="text" id="fname" class="form-control" name="fname" placeholder="Name" value="" />
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">

                                <input type="text" id="email" class="form-control" name="email" placeholder="Email ID" value="" />
                            </div>

                            <div class="col-md-6">

                                <input type="text" id="mobile" class="form-control" name="mobile" placeholder="Mobile/Cell Number" value="" />
                                <br />
                                <div>
                                    <input type="submit" value="Proceed to Payment" class="btn btn-success" onclick="launchBOLT(); return false;" />
                                    <br />
                                    <br />
                                </div>
                            </div>

                            <input type="hidden" id="udf5" name="udf5" value="BOLT_KIT_ASP.NET" />
                            <input type="hidden" id="surl" name="surl" value="<%= Session["surl"]%>" />
                            <div class="dv" style="display: none">
                                <input type="text" id="txnid" name="txnid" placeholder="Transaction ID" value="<%=Session["txnid"] %>" />
                            </div>
                            <div class="dv" style="display: none">
                                <input type="text" id="hash" class="form-control" name="hash" placeholder="Hash" value="" />
                            </div>
                            <div class="dv" style="display: none">
                                <input type="text" id="pinfo" class="form-control" name="pinfo" placeholder="Product Info" value="Donations" />
                            </div>



                        </div>
                    </div>
                </div>
           
   

    <script type="text/javascript"><!--
    $(document).ready(function () {
        $('#payment_form').keyup(function () {
            $.ajax({
                url: 'Hash.aspx',
                type: 'post',
                data: JSON.stringify({
                    key: "R4t9x9Lu",
                    salt: "y2K5B8gSfg",
                    txnid: $('#txnid').val(),
                    amount: $('#amount').val(),
                    pinfo: $('#pinfo').val(),
                    fname: $('#fname').val(),
                    email: $('#email').val(),
                    mobile: $('#mobile').val(),
                    udf5: $('#udf5').val()
                }),
                contentType: "application/json",
                dataType: 'json',
                success: function (json) {
                    if (json['error']) {
                        $('#alertinfo').html('<i class="fa fa-info-circle"></i>' + json['error']);
                    }
                    else if (json['success']) {
                        $('#hash').val(json['success']);
                    }
                }
            });
        });
    });
//-->
    </script>
    <script type="text/javascript"><!--
    function launchBOLT() {
        bolt.launch({
            key: "R4t9x9Lu",
            salt: "y2K5B8gSfg",
            txnid: $('#txnid').val(),
            hash: $('#hash').val(),
            amount: $('#amount').val(),
            firstname: $('#fname').val(),
            email: $('#email').val(),
            phone: $('#mobile').val(),
            productinfo: $('#pinfo').val(),
            udf5: $('#udf5').val(),
            surl: $('#surl').val(),
            furl:$('#surl').val(),
        }, {
                responseHandler: function (BOLT) {
                    console.log(BOLT.response.txnStatus);
                    if (BOLT.response.txnStatus != 'CANCEL') {
                        //Salt is passd here for demo purpose only. For practical use keep salt at server side only.
                        var fr = '<form action=\"' + $('#surl').val() + '\" method=\"post\">' +
                            '<input type=\"hidden\" name=\"key\" value=\"' + BOLT.response.key + '\" />' +
                            '<input type=\"hidden\" name=\"salt\" value=\"' + $('#salt').val() + '\" />' +
                            '<input type=\"hidden\" name=\"txnid\" value=\"' + BOLT.response.txnid + '\" />' +
                            '<input type=\"hidden\" name=\"amount\" value=\"' + BOLT.response.amount + '\" />' +
                            '<input type=\"hidden\" name=\"productinfo\" value=\"' + BOLT.response.productinfo + '\" />' +
                            '<input type=\"hidden\" name=\"firstname\" value=\"' + BOLT.response.firstname + '\" />' +
                            '<input type=\"hidden\" name=\"email\" value=\"' + BOLT.response.email + '\" />' +
                            '<input type=\"hidden\" name=\"udf5\" value=\"' + BOLT.response.udf5 + '\" />' +
                            '<input type=\"hidden\" name=\"mihpayid\" value=\"' + BOLT.response.mihpayid + '\" />' +
                            '<input type=\"hidden\" name=\"status\" value=\"' + BOLT.response.status + '\" />' +
                            '<input type=\"hidden\" name=\"hash\" value=\"' + BOLT.response.hash + '\" />' +
                            '</form>';
                        var form = jQuery(fr);
                        jQuery('body').append(form);
                        form.submit();
                    }
                },
                catchException: function (BOLT) {
                    alert(BOLT.message);
                }
            });
    }
    //--
    </script>

</asp:Content>
