

ready(function () {
    let btn = document.getElementById('btnSave');
    //btn.addEventListener('click', function () {

    //}, false);

        btn.addEventListener('click', function () {
            (async () => {
                let sname = document.getElementById('txtSname').value;
                let fname = document.getElementById('txtFname').value;
                let code = document.getElementById('txtCode').value;
                let lid = document.getElementById('ddlLocation').value;

                let mo = {};
                mo.SNm = sname;
                mo.FNm = fname;
                mo.MCd = code;
                mo.LoId = lid;

                const response = await fetch('/MO/save', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(mo)
                });

                if (response.ok) {
                    const isJson = response.headers.get('content-type')?.includes('application/json');
                    const data = isJson && await response.json();
                    if (data && data.success === true) {
                        Swal.fire({
                            title: "Done",
                            text: "Record Save Successfully",
                            icon: "success"
                        }).then((result) => {
                            window.location.href = '/MO/Molist';
                        });
                    } else {
                        Swal.fire({
                            title: "Something went wrong Try Again",
                            text: "An error occurred while saving",
                            icon: "error"
                        });
                    }
                } else {
                    Swal.fire({
                        title: "Something went wrong Try Again",
                        text: "An error occurred while saving",
                        icon: "error"
                    });
                }
            })();
        }, false);
    });

