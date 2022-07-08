import toastr from "toastr/build/toastr.min.js";

function unauthorized(error, router) {
    let self = this;
    if (error.response.status === 401) {
          localStorage.removeItem('token');
          toastr.warning("Session expired redirecting...", "Unauthorized");
          setTimeout(() => {
            router.go();
          },2000);
        }
        else {
          toastr.error("Some error occured", "Error");
        } 
  }
  function validationErrorResponse(error, router) {
    if (error.response.status === 422) {
      let message = "";

      error.response.data.errors.forEach((e) => {
        message += `<li>${e.ErrorMessage} </li>`;
      });
      toastr.error(message, error.response.data.title);
    } else {
      this.unauthorized(error, router);
    }   
  }

  export {unauthorized, validationErrorResponse}