ready(function () {
    let btn = document.getElementById('btnUpdate');

    btn.addEventListener('click', function () {

        (async () => {
            let lid = document.getElementById('txtLID').value;
            let sname = document.getElementById('txtSname').value;
            let fname = document.getElementById('txtFname').value;
            let code = document.getElementById('txtCode').value;

            let lo = {};
            lo.LID = lid;
            lo.SNm = sname;
            lo.FNm = fname;
            lo.LCd = code;

            const response = await fetch('/location/submitupdate', {
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
                    }).then((result) => {
                        window.location.href = '/location/lolist';
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
