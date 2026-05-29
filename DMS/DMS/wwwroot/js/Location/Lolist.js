const abc = async () => {
    try {
        const res = await fetch('/location/getLoData');

        if (res.ok) {
            const isJson = res.headers.get('content-type')?.includes('application/json');
            let data = isJson && await res.json();
            return data;
        }

        else {
            iziToast.error({
                message: res.statusText,
            });
        }
    }
    catch (error) {
        iziToast.error({
            message: error,
        });
    }
    return null;
}


ready(function () {
    let tbl = document.getElementById('DT_Load');
    let tbody = tbl.getElementsByTagName("tbody");
    if (tbody && tbody.length > 0)
        tbl.removeChild(tbody[0]);
    tbody = tbl.createTBody();

    (async () => {
        let data = await abc();
        console.log("Received data:", data);
        let htm = '';
        data.xyz.forEach((r) => {
            htm += '<tr>';
            htm += '<td>';
            htm += r.loCode;
            htm += '</td>';
            htm += '<td>';
            htm += r.shortName;
            htm += '</td>';
            htm += '<td>';
            htm += r.fullName;
            htm += '</td>';
            htm += '<td><a class="btn btn-link link-primary" href = "/Location/Update/' + r.loID + '" > Edit</a>&nbsp;<button class="btn btn-link link-danger" onclick="deleteLo('+r.loID+')">Delete</button></td>';
            htm += '</tr>';

        });

        tbody.innerHTML = htm;
    })();


});

async function deleteLo(id) {
    const result = await Swal.fire({
        title: 'Are you sure?',
        text: "This action cannot be undone.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'Cancel'
    });

    if (result.isConfirmed) {
        const res = await fetch(`/location/delete/${id}`, { method: 'DELETE' });
        const data = await res.json();

        if (data.success) {
            Swal.fire('Deleted!', data.msg, 'success').then(() => {
                window.location.reload();
            });
        } else {
            Swal.fire('Error!', data.msg, 'error');
        }
    }
}