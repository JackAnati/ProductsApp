const submitBtn = document.getElementById("btn-save");
const deleteModal = document.getElementById("deleteModal");
const confirmDelete = document.getElementById("confirmDeleteBtn");
const name = document.getElementById("name").value.trim();
const price = document.getElementById("price").value.trim();
const description = document.getElementById("description").value.trim();

submitBtn.addEventListener("click", function (event) {
   
    if (name === "" || price === "" || description === "") {
        event.preventDefault();
        alert("Please fill in all fields");
    }
});

function openDeleteModal(productId) {
    deleteModal.style.display = "block";
    confirmDelete.href = "/Product/Delete/" + productId;
}

function closeDeleteModal() {
    deleteModal.style.display = "none";
}