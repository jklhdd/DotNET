(function () {

    $(function () {
        console.log('Enabled "Auto adding token to Swagger API" after click "Try it out" in "POST /api/v1/token" section');

        var selector = '#resource_Auth .response .block.response_body';
        $(selector).bind("DOMSubtreeModified", function () {
            //get token
            var tokenResponse = $(selector + ' code').text();
            if (tokenResponse.length === 0) return;

            //get token value
            var tokenObj = JSON.parse(tokenResponse);
            if (tokenObj == null) return;
            var token = tokenObj.access_token;

            //set swagger header
            var key = "Bearer " + token;
            var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", key, "header");
            window.swaggerUi.api.clientAuthorizations.add("key", apiKeyAuth);
            console.log("added Bearer key to Swagger with content: " + key);
            //setCookie("ShowHangfire", true, 1);
        });
    });
})();

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
