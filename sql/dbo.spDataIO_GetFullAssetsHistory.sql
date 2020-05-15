-- =============================================
-- Author:		Sean Tuck
-- Create date: 2020-05-11
-- Description:	Data I/O history for display in data tracking form, with optional filter pars.
-- =============================================
USE DAT_CMS
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spDataIO_GetFullAssetsHistory
	@DateFrom DATETIME = null,
	@DateTo DATETIME = null,
	@ProjectNumber VARCHAR(5) = null, 
	@VreFilePath VARCHAR(200) = null
	--@ImportType BIT = null,
	--@ExportType BIT = null
	--@DeleteType BIT = null,
	--@Approved BIT = null,
	--@Rejected BIT = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		cl.RequestID, cl.AssetID, cl.ChangeAccepted,
				ar.AssetSha256sum, ar.VreFilePath,
				rq.ChangeDate, rq.RequestedBy, rq.ChangedBy,
				pr.ProjectNumber,
				ct.ChangeTypeLabel 
	FROM		dbo.tblAssetsChangeLog		AS cl 
	INNER JOIN	dbo.tblAssetsRegister		AS ar	ON cl.AssetID = ar.AssetID 
	INNER JOIN	dbo.tblDataIORequests		AS rq	ON cl.RequestID = rq.RequestID
	INNER JOIN	dbo.tblProject				AS pr	ON ar.Project = pr.pID AND rq.Project = pr.pID
	INNER JOIN	dbo.tlkAssetChangeTypes		AS ct	ON rq.ChangeType = ct.ChangeTypeID
	WHERE		(rq.ChangeDate >= @DateFrom OR @DateFrom IS NULL OR rq.ChangeDate IS NULL)	AND 
				(rq.ChangeDate <= @DateTo OR @DateTo IS NULL OR rq.ChangeDate IS NULL)		AND
				(pr.ProjectNumber = @ProjectNumber OR @ProjectNumber IS NULL)				AND
				(ar.VreFilePath = @VreFilePath OR @VreFilePath IS NULL)
	ORDER BY	rq.ChangeDate, pr.ProjectNumber ASC
END
GO
