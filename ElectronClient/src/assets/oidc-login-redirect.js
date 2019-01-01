debugger;
var config = {
    userStore: new Oidc.WebStorageStateStore({ store: window.localStorage })
  };
  var mgr = new Oidc.UserManager(config);
  mgr.signinRedirectCallback().then(() => {
        window.history.replaceState({},
            window.document.title,
            window.location.origin);
    window.location = `file://${__dirname}/index.html`;
    }, error => {
        console.error(error);
    });
