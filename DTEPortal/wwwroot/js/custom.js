 $('.dataTable').DataTable(
    /* {  responsive: false   }*/
);


$('.Alert-Confirmation').click(function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Do you want to save this record ?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085D6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: 'Record Saved Successfully!',
                timer: 2000
            }
            )
        }
    })
});

$('.Alert-Confirmation-Edit').click(function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Do you want to Update this record ?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085D6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: 'Record Updated Successfully!',
                timer: 2000
            }
            )
        }
    })
});
//$('.Alert-Edit').click(function () {
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "Do you want to Edit this record ?",
//        type: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085D6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes'
//    }).then((result) => {
//        if (result.value) {
//            //Swal.fire({
//            //    type: 'success',
//            //    title: 'Success!',
//            //    text: 'Record Deleted Successfully!',
//            //    timer: 2000
//            //}
//            //)
//            Response.redirect(this.href.tostring());
//        }
//    })
//});
$('.Alert-Edit').click(function (event) {
    // Prevent the default action of the link
    event.preventDefault();

    // Store the href of the clicked element
    const href = this.href;

    Swal.fire({
        title: 'Are you sure?',
        text: "Do you want to Edit this record?",
        icon: 'warning', // Use 'icon' instead of 'type' in newer SweetAlert versions
        showCancelButton: true,
        confirmButtonColor: '#3085D6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes',
        cancelButtonText:'No'
    }).then((result) => {
        if (result.isConfirmed) { // Check if the user clicked 'Yes'
            // Redirect to the href
            window.location.href = href;
        }
    });
});
$('.Alert-Delete').click(function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Do you want to Delete this record ?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085D6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: 'Record Deleted Successfully!',
                timer: 2000
            })
        }
    })
});

//(function ($) {
//    "use strict"
//    document.querySelector(".Alert-Save").onclick = function () {
//        Swal.fire("Oops...", "Something went wrong !!", "error")
//    }
//        ,
//        document.querySelector(".sweet-message").onclick = function () {
//            Swal.fire("Hey, Here's a message !!")
//        }
//        ,
//        document.querySelector(".sweet-text").onclick = function () {
//            Swal.fire("Hey, Here's a message !!", "It's pretty, isn't it?")
//        }
//        ,
//        document.querySelector(".sweet-success").onclick = function () {
//            Swal.fire("Hey, Good job !!", "You clicked the button !!", "success")
//        }
//        ,
//        document.querySelector(".sweet-confirm").onclick = function () {
//            Swal.fire({
//                title: "Are you sure to delete ?",
//                text: "You will not be able to recover this imaginary file !!",
//                type: "warning",
//                showCancelButton: !0,
//                confirmButtonColor: "#DD6B55",
//                confirmButtonText: "Yes, delete it !!",
//                closeOnConfirm: !1
//            }, function () {
//                Swal.fire("Deleted !!", "Hey, your imaginary file has been deleted !!", "success")
//            })
//        }
//        ,
//        document.querySelector(".sweet-success-cancel").onclick = function () {
//            Swal.fire({
//                title: "Are you sure to delete ?",
//                text: "You will not be able to recover this imaginary file !!",
//                type: "warning",
//                showCancelButton: !0,
//                confirmButtonColor: "#DD6B55",
//                confirmButtonText: "Yes, delete it !!",
//                cancelButtonText: "No, cancel it !!",
//                closeOnConfirm: !1,
//                closeOnCancel: !1
//            }, function (e) {
//                e ? Swal.fire("Deleted !!", "Hey, your imaginary file has been deleted !!", "success") : Swal.fire("Cancelled !!", "Hey, your imaginary file is safe !!", "error")
//            })
//        }
//        ,
//        document.querySelector(".sweet-image-message").onclick = function () {
//            Swal.fire({
//                title: "Sweet !!",
//                text: "Hey, Here's a custom image !!",
//                imageUrl: "images/hand.png",
//                imageWidth: "20%"
//            })
//        }
//        ,
//        document.querySelector(".sweet-html").onclick = function () {
//            Swal.fire({
//                title: "Sweet !!",
//                text: "<span style='color:#ff0000'>Hey, you are using HTML !!<span>",
//                html: !0
//            })
//        }
//        ,
//        document.querySelector(".sweet-auto").onclick = function () {
//            Swal.fire({
//                title: "Sweet auto close alert !!",
//                text: "Hey, i will close in 2 seconds !!",
//                timer: 2e3,
//                showConfirmButton: !1
//            })
//        }
//        ,
//        document.querySelector(".sweet-prompt").onclick = function () {
//            Swal.fire({
//                title: "Enter an input !!",
//                text: "Write something interesting !!",
//                type: "input",
//                showCancelButton: !0,
//                closeOnConfirm: !1,
//                animation: "slide-from-top",
//                inputPlaceholder: "Write something"
//            }, function (e) {
//                return !1 !== e && ("" === e ? (swal.showInputError("You need to write something!"),
//                    !1) : void Swal.fire("Hey !!", "You wrote: " + e, "success"))
//            })
//        }
//        ,
//        document.querySelector(".sweet-ajax").onclick = function () {
//            Swal.fire({
//                title: "Sweet ajax request !!",
//                text: "Submit to run ajax request !!",
//                type: "info",
//                showCancelButton: !0,
//                closeOnConfirm: !1,
//                showLoaderOnConfirm: !0
//            }, function () {
//                setTimeout(function () {
//                    Swal.fire("Hey, your ajax request finished !!")
//                }, 2e3)
//            })
//        }
//        ;

//}
//)(jQuery);
