<%@ Page Title="Bubble Manager" Language="C#" AutoEventWireup="true" CodeFile="FormSubmitted.aspx.cs" Inherits="FormSubmitted" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Raleway" />
    <link rel="stylesheet" type="text/css" href="Content/StyleSheet.css" />
    <style>
        body {
            text-align: center;
            font-family: 'Raleway';
            margin: auto;
            height: 100%;
            width: 100%
        }

        img {
            margin: 20px auto;

            vertical-align: middle;
            max-height: 200px;
            max-width: 75%;
        }

        p {
            font-size: 1.2em;
            line-height: 1.5;
            font-weight: normal;
        }
        .CustNum {
            display:inline;
        }

        .button {
            display: block;
            margin: auto;
            max-width: 100%;
        }

        #divThankYou img {
            margin: 0;
            padding: 0;
            padding-left: 22px;
        }
        #redirectDiv div {
            width: auto;
            display: inline-block;
            margin-top: 10px;
            font-size: 1.2em;
        }

       #pnlFormSubmitted {
           max-width: 90vw;
           margin: 20px auto;
       }
    </style>

    <title>Bubble Manager</title>
</head>

<body runat="server" id="pagebody">
    <img src="Content/logo.png" alt="Welcome to Bubble Manager!" id="imgLogo" />
    <asp:Panel runat="server" ID="pnlFormSubmitted" Style=" padding: 20px" CssClass="pnlCSS">
        <div id="divThankYou" runat="server">
            <img src="Content/success.png" height="120" />
            <h1 style="margin: 0">Thank you!</h1>
            <p style="margin-top: 0">
                Your information has been uploaded to our database.<br />
                You are one step closer to the underwater world!
                            <br />
                <span class="CustNum">Your customer ID is <span id="IDnum" class="CustNum" style="font-weight: bold; font-size: 16pt;" runat="server"></span>.</span>
                </p>
                <input type="button" id="btnRefresh" value="Add Another Customer" class="button" onclick="redirect()" />
        </div>
    </asp:Panel>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>
<script src="Scripts/FormSubmitted.js" type="text/javascript"></script>
</html>
