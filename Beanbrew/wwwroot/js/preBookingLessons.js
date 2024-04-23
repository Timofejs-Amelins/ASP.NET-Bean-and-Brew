


document.getElementById("bookBakingLessonButton").addEventListener("click", displayBakingLessonBookingForm)

function displayBakingLessonBookingForm() {
    document.getElementById("bakingLessonBookingForm").innerHTML = `
            <div class="form-group">
                <label class="control-label">Day</label>
                <input class="form-control" type="number" id="day"/>
            </div>
            <div class="form-group">
                <label class="control-label">Month</label>
                <input class="form-control" type="number" id="month"/>
            </div>
            <div class="form-group">
                <label class="control-label">Year</label>
                <input class="form-control" type="number" id="year"/>
            </div>
            <div class="form-group">
                <label class="control-label">Hour</label>
                <input class="form-control" type="number" id="hour"/>
            </div>
            <div class="form-group">
                <label class="control-label">Minute</label>
                <input class="form-control" type="number" id="minute"/>
            </div>
            <div class="form-group">
                <label class="control-label">AM or PM?</label>
                <input class="form-control" id="amOrPm"/>
            </div>
            <div class="form-group">
                <button class="btn btn-primary" id="bakingLessonBookingFormSubmissionButton">Submit</button>
            </div>`

    document.getElementById("bakingLessonBookingFormSubmissionButton").addEventListener("click", displayBakingLessonBookingReciept)
    function displayBakingLessonBookingReciept() {
        document.getElementById("bakingLessonBookingReciept").innerHTML = `<table>
        <tr>
            <th>
                Baking Lesson Booking Reciept - save it!
            </th>
        </tr>
        <tr>
            <td>
                Location: Bean and Brew Leeds
            </td>
        </tr>
        <tr>
            <td>
                Date: ` + document.getElementById("day").value + `/` + document.getElementById("month").value + `/` + document.getElementById("year").value + `
            </td>
        </tr>
        <tr>
            <td>
                Time: ` + document.getElementById("minute").value + ` minutes past ` + document.getElementById("hour").value + document.getElementById("amOrPm").value + `
            </td>
        </tr>
    </table>`
    }
}











