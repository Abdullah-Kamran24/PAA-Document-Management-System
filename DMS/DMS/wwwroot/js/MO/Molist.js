const fetchMainOffices = async () => {
    try {
        const res = await fetch('/MO/GetMoData');
        if (res.ok) {
            const data = await res.json();
            return data;
        } else {
            iziToast.error({ message: res.statusText });
        }
    } catch (error) {
        iziToast.error({ message: error.message });
    }
    return null;
};

ready(async function () {
    const data = await fetchMainOffices();
    if (!data || !data.records) return;

    const tbody = document.querySelector("#DT_Load tbody");
    tbody.innerHTML = "";

    data.records.forEach((r) => {
        let tr = document.createElement("tr");

        let htm = '';
        htm += '<td>' + r.moCode + '</td>';
        htm += '<td>' + r.shortName + '</td>';
        htm += '<td>' + r.fullName + '</td>';
        htm += '<td>' + r.locationName + '</td>'; 
        htm += `<td>
                    <a class="btn btn-link link-primary" href="/MO/Update/${r.moID}">Edit</a>
                    &nbsp;
                    <button class="btn btn-link link-danger" onclick="deleteMo(${r.moID})">Delete</button>
                </td>`;

        tr.innerHTML = htm;
        tbody.appendChild(tr);
    });
});



function deleteMo(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won’t be able to undo this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/MO/Delete/${id}`, {
                method: 'DELETE'
            }).then(res => {
                if (res.ok) {
                    Swal.fire('Deleted!', 'The record has been deleted.', 'success').then(() => {
                        location.reload(); // or call fetchMainOffices() again
                    });
                } else {
                    Swal.fire('Error!', 'Something went wrong.', 'error');
                }
            });
        }
    });
}

