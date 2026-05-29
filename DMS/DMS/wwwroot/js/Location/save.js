

ready(function () {
    let btn = document.getElementById('btnSave');
    //btn.addEventListener('click', function () {

    //}, false);


    btn.addEventListener('click', function () {

        (async () => {
            let sname = document.getElementById('txtSname').value;
            let fname = document.getElementById('txtFname').value;
            let code = document.getElementById('txtCode').value;

            let lo = {};
            lo.SNm = sname;
            lo.FNm = fname;
            lo.LCd = code;
            const response = await fetch('/location/save', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(lo)
            });
            if (response.ok) {
                const isJson = response.headers.get('content-type')?.includes('application/json');
                const data = isJson && await response.json();
                if (data && data.success == true) {
                    Swal.fire({
                        title: "Done",
                        text: "Record Save Successfully",
                        icon: "success"
                    }).then((result) => {
                        window.location.href = '/location/lolist';
                    });
                }
                else {
                    Swal.fire({
                        title: "Something went wrong Try Again",
                        text: "An error occurred while saving",
                        icon: "error"
                    });
                }
            }
            else {
                Swal.fire({
                    title: "Something went wrong Try Again",
                    text: "An error occurred while saving",
                    icon: "error"
                });
            }
        })();
    }, false);

});
