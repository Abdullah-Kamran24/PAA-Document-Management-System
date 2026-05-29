ready(function () {
    let btn = document.getElementById('btnUpdate');

    btn.addEventListener('click', function () {

        (async () => {
            let lid = document.getElementById('txtMoID').value;
            let sname = document.getElementById('txtSname').value;
            let fname = document.getElementById('txtFname').value;
            let code = document.getElementById('txtCode').value;
            let ddl = document.getElementById('ddlLocation').value;

            let lo = {};
            lo.MID = lid;
            lo.SNm = sname;
            lo.FNm = fname;
            lo.MCd = code;
            lo.LoId = ddl;

            const response = await fetch('/MO/submitupdate', {
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
                        title: "Asking Again! Do you want to save the changes?",
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: "Save",
                        denyButtonText: `Don't save`
                    }).then((result) => {
                        if (result.isConfirmed) {
                            Swal.fire("Saved!", "", "success").then(() => {
                                window.location.href = '/MO/molist';
                            });
                        } else if (result.isDenied) {
                            Swal.fire("Changes are not saved", "", "info");
                        }
                    });
                  
                } else {
                    Swal.fire({
                        title: "Asking Again! Do you want to save the changes?",
                        showDenyButton: true,
                        showCancelButton: true,
                        confirmButtonText: "Save",
                        denyButtonText: `Don't save`
                    })
                    
                }
            } else {
                Swal.fire({
                    title: "Asking Again! Do you want to save the changes?",
                    showDenyButton: true,
                    showCancelButton: true,
                    confirmButtonText: "Save",
                    denyButtonText: `Don't save`
                })
                
            }
        })();

    }, false);
});
