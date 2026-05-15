const prevBtn = document.getElementById("prev-btn")
const nextBtn = document.getElementById("next-btn")
const addCourseBtn = document.getElementById("add-course-btn")

const courseDetails = document.getElementById("course-details")
const materialDetails = document.getElementById("material-details")
const revisionDetails = document.getElementById("revision-details")

const courseStep = document.getElementById("course-step")
const materialStep = document.getElementById("material-step")
const revisionStep = document.getElementById("revision-step")

const form = document.getElementById("course-material-form")

const allAccordions = document.getElementById("all-accordions")

const CourseTitle = document.getElementById("CourseTitle")
const CourseDescription = document.getElementById("CourseDescription")

const getCourseTitle = document.getElementById("get-course-title")
const getCourseDesc = document.getElementById("get-course-desc")

const addionalMaterial = document.getElementById("addional-material")

const closeBtn = document.getElementById("close-btn")
 
let accNew = null;

let count =1

nextBtn.addEventListener("click", () => {
    if (prevBtn.hidden) {
        const data = new FormData(form)
        const formValues = Object.fromEntries(data.entries());
        if (formValues["CourseTitle"] && formValues["CourseDescription"]) {
            courseDetails.hidden = true;
            materialDetails.hidden = false;
            prevBtn.hidden = false;
            materialStep.classList.add("step-primary");
            document.getElementById("warning-CourseTitle").hidden = true
            document.getElementById("warning-CourseDescription").hidden = true
        }
        else {
            if (!formValues["CourseTitle"] && !formValues["CourseDescription"]) {
                document.getElementById("warning-CourseTitle").hidden = false
                document.getElementById("warning-CourseDescription").hidden = false

            }
            else if (formValues["CourseDescription"] && !formValues["CourseTitle"]) {
                document.getElementById("warning-CourseTitle").hidden = false
                document.getElementById("warning-CourseDescription").hidden = true
            }
            else if (formValues["CourseTitle"] && !formValues["CourseDescription"]) {
                document.getElementById("warning-CourseTitle").hidden = true
            document.getElementById("warning-CourseDescription").hidden = false
            }
            }
    }
    else {
        const data = new FormData(form)
        const formValues = Object.fromEntries(data.entries());
        let goToNext = true
        let sumNumbers = {}
        console.log(Object.entries(formValues))
        Object.entries(formValues).forEach(([key, value]) => {
            
            if (!value && key != "__RequestVerificationToken") {
                goToNext = false
                sumNumbers[key[key.length - 1]] = 1
                document.querySelector(`#warning-${key}`).hidden = false
            }
            else if (value && key != "__RequestVerificationToken") {
                console.log(key)
                document.querySelector(`#warning-${key}`).hidden = true            }
        });
        document.querySelectorAll("summary").forEach(x => x.classList.remove("border-2", "border-error", "text-error"))
        Object.entries(sumNumbers).forEach(([key, value]) => {
            document.querySelector(`#summary-Material-${key}`).classList.add("border-2", "border-error", "text-error")
        })
        if (goToNext) {
            materialDetails.hidden = true;
            revisionDetails.hidden = false
            nextBtn.hidden = true
            addCourseBtn.hidden = false
            revisionStep.classList.add("step-primary");
            //Revision stuff

            let copy = allAccordions.cloneNode(true)
            copy.children[0].remove()
            copy.querySelectorAll('input').forEach((x) => {
                x.readOnly = true
                x.classList.add("border-0")
            })
            copy.querySelectorAll('select').forEach(x => {
                x.disabled = true
                x.value = allAccordions.querySelector(`#${x.id}`).value
                x.classList.add("border-0")
            })
            accNew = revisionDetails.appendChild(copy)
            getCourseTitle.textContent = CourseTitle.value
            getCourseDesc.textContent = CourseDescription.value
        }
            
    }
})

prevBtn.addEventListener("click", () => {
    if (addCourseBtn.hidden) {
        courseDetails.hidden = false;
        materialDetails.hidden = true;
        prevBtn.hidden = true;
        materialStep.classList.remove("step-primary")
    }
    else {
        courseDetails.hidden = true;
        materialDetails.hidden = false;
        prevBtn.hidden = false;
        materialStep.classList.add("step-primary");

        materialDetails.hidden = false;
        revisionDetails.hidden = true
        nextBtn.hidden = false
        addCourseBtn.hidden = true
        revisionStep.classList.remove("step-primary");

        accNew.remove()
    }
})

addionalMaterial.addEventListener("click", () => {
    count++
    const singleAccordion = `
                        <details class="collapse bg-base-100 border border-base-300" name="my-accordion-det-1" open>
                            <summary id="summary-Material-${count}"class="collapse-title font-semibold text-center">#${count} Material </summary>
                                <div class="collapse-content text-sm flex flex-col gap-6">
                                <div class="flex justify-between">
                                    <label class="floating-label">
                                        <span>Title</span>
                                            <input required id="MaterialTitle-${count}" name="MaterialTitle-${count}" type="text" placeholder="mail@site.com" class="input input-md w-70" />
                                    <p id="warning-MaterialTitle-${count}" class="text-left text-error mt-4" hidden>
    Required
    </p>
                                            </label>
                                        <select required class="select w-70" id="MaterialType-${count}" name="MaterialType-${count}">
 
                                    </select>
                                    <p id="warning-MaterialType-${count}" class="text-left text-error mt-4" hidden>
    Required
    </p>
                                    </div>
                                    <label class="floating-label">
                                        <span>Description</span>
                                        <input required id="MaterialDescription-${count}" name="MaterialDescription-${count}" type="text" placeholder="mail@site.com" class="input input-md w-full" />
                                    <p id="warning-MaterialDescription-${count}" class="text-left text-error mt-4" hidden>
                                        Required
                                        </p>
                                        </label>
                                    <label class="input  input-md w-full">
                                        <span class="label">https://</span>
                                        <input required id="MaterialUrl-${count}" name="MaterialUrl-${count}" type="text" placeholder="URL" />
                                    
                                        </label>
                                        <p id="warning-MaterialUrl-${count}" class="text-left text-error " hidden>
                                        Required
                                        </p>
                            </div>
                        </details>

    `
    allAccordions.insertAdjacentHTML('beforeend', singleAccordion);
    let copy = document.getElementById("MaterialType-1").cloneNode(true)
    copy.id = `MaterialType-${count}`
    copy.name = `MaterialType-${count}`
    document.getElementById(`MaterialType-${count}`).replaceWith(copy)

    if (count == 5)
        addionalMaterial.hidden=true
})

closeBtn.addEventListener("click", () => {
    form.reset()
    count = 1
    while (allAccordions.children.length!=2) {
        allAccordions.children[allAccordions.children.length - 1].remove()
        console.log("removed")
    }
}


)